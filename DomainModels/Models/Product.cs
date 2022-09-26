﻿namespace DomainModels.Models
{
    public class Product : BaseModel
    {
        public string Symbol { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime IssuanceAt { get; set; }
        public DateTime ExpirationAt { get; set; }
        public int DaysToExpire { get; set; }
        public ProductType Type { get; set; }
        public IList<Portfolio> Porfolios { get; set; } = new List<Portfolio>();
        public IList<Order> Orders { get; set; } = new List<Order>();

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
