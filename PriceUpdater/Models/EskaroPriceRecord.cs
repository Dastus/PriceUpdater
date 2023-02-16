using PriceUpdater.Extensions;

namespace PriceUpdater.Models
{
    public class EskaroPriceRecord
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string VendorCode { get; set; }
        public string Price { get; set; }
        public string Unit { get; set; }

        public static EskaroPriceRecord Deserialize(IEnumerable<string> line)
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

            return new EskaroPriceRecord
            {
                Name = rowDataList[1],
                VendorCode = rowDataList[2].NormalizeArticool(),
                Barcode = rowDataList[3],
                Price = rowDataList[4].NormalizePrice(),
                Unit = rowDataList[5]
            };
        }
    }
}
