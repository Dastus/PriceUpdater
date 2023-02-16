using PriceUpdater.Extensions;

namespace PriceUpdater.Models
{
    public class ElectrotoolsPriceRecord
    {
        public string Name { get; set; }
        public string RestAmount { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string PriceUSD { get; set; }
        public string Unit { get; set; }

        public static ElectrotoolsPriceRecord Deserialize(IEnumerable<string> line)
        {
            if (line == null
                || line.Count() < 6)
            {
                return null;
            }

            var rowDataList = line.ToList();

            if (string.IsNullOrEmpty(rowDataList[1])
                || string.IsNullOrEmpty(rowDataList[2])
                || string.IsNullOrEmpty(rowDataList[3])
                || string.IsNullOrEmpty(rowDataList[4])
                || string.IsNullOrEmpty(rowDataList[5]))
            {
                return null;
            }

            return new ElectrotoolsPriceRecord
            {
                Name = rowDataList[1],
                RestAmount = rowDataList[2],
                VendorCode = rowDataList[3].NormalizeArticool(),
                VendorName = rowDataList[4],
                PriceUSD = rowDataList[5].NormalizePrice(),
                Unit = rowDataList[6]
            };
        }
    }
}
