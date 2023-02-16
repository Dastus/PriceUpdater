namespace PriceUpdaterApp.Models
{
    public class PriceChangeRecord
    {
        public string VendorCode { get; set; }
        public string Name { get; set; }
        public string OldPrice { get; set; }
        public string NewPrice { get; set; }
    }
}
