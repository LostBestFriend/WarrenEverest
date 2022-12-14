namespace DomainModels.Models
{
    public class Product : BaseModel
    {
        public string Symbol { get; set; }
        public DateTime IssuanceAt { get; set; }
        public DateTime ExpirationAt { get; set; }
        public int DaysToExpire { get; set; }
        public ProductType Type { get; set; }
        public ICollection<Portfolio> Porfolios { get; set; } = Array.Empty<Portfolio>();
        public ICollection<Order> Orders { get; set; } =  Array.Empty<Order>();

        public Product(string symbol, DateTime issuanceAt, DateTime expirationAt, int daysToExpire, ProductType type)
        {
            Symbol = symbol;
            IssuanceAt = issuanceAt;
            ExpirationAt = expirationAt;
            DaysToExpire = daysToExpire;
            Type = type;
        }
    }
}
