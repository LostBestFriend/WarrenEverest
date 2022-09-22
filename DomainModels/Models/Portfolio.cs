namespace DomainModels.Models
{
    public class Portfolio : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalBalance { get; set; }
        public Customer Customer { get; set; }
        public long CustomerId { get; set; }
        public ICollection<Product> Products { get; set; } = Array.Empty<Product>();
        public ICollection<Order> Orders { get; set; } = Array.Empty<Order>();

        public Portfolio(string name, string description, decimal totalBalance, long customerId)
        {
            Name = name;
            Description = description;
            TotalBalance = totalBalance;
            CustomerId = customerId;
        }
    }
}
