using PriceUpdater.Extensions;

namespace PriceUpdater.Models
{
    public class PervijDomPriceRecord
    {
        public string Name { get; set; }
        public string PriceWholesale { get; set; }
        public string Discount { get; set; }
        public string PriceDiscount { get; set; }

        public static PervijDomPriceRecord Deserialize(string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                return null;
            }

            var strings = line.Split(' ').ToList();

            if (strings.Count < 4)
            {
                return null;
            }
            
            var priceDiscount = strings[strings.Count - 1];
            if (!double.TryParse(priceDiscount, out var _))
            {
                return null;
            }

            var discount = strings[strings.Count - 2];
            var priceWholesale = strings[strings.Count - 3];
            if (!double.TryParse(priceWholesale, out var _))
            {
                return null;
            }

            var name = "";
            if (strings.Count == 4)
            {
                name = strings[strings.Count - 4];
            }
            else
            {
                name = string.Join(' ', strings.GetRange(0, strings.Count - 3));
            }

            return new PervijDomPriceRecord
            {
                Name = name,
                PriceWholesale = priceWholesale,
                Discount = discount,
                PriceDiscount = priceDiscount.NormalizePrice()
            };
        }
    }
}
