using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceUpdater.Extensions
{
    public static class StringExtensions
    {
        public static string NormalizeArticool(this string articool)
        {
            return articool.Trim().RemoveLeadingZeroes();
        }

        public static string RemoveLeadingZeroes(this string text)
        {
            var firstNonZeroSymbolIndex = 0;
            
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != '0')
                {
                    firstNonZeroSymbolIndex = i;
                    break;                
                }                
            }

            return text.Substring(firstNonZeroSymbolIndex);
        }

        public static string RemoveCurrency(this string text)
        {
            return text.ToLower()
                .Replace(" грн", string.Empty)
                .Replace(" uah", string.Empty)
                .Replace(" usd", string.Empty);
        }

        public static string NormalizePrice(this string text)
        {
            text = text.Trim().RemoveCurrency();

            if (text.Contains(",") && text.Contains("."))
            {
                return text.Replace(",", "");
            }

            return text.Replace(",", ".");
        }
    }
}
