using AppModels.Enums;

namespace AppModels.Mapper
{
    public class UpdateProduct
    {
        public string Symbol { get; set; }
        public DateTime IssuanceAt { get; set; }
        public DateTime ExpirationAt { get; set; }
        public int DaysToExpire { get; set; }
        public ProductType Type { get; set; }
    }
}
