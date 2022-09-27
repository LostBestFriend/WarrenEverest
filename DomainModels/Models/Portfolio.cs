namespace DomainModels.Models
{
    public class Portfolio : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalBalance { get; set; }
        public Customer Customer { get; set; }
        public long CustomerId { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
        public IList<Order> Orders { get; set; } = new List<Order>();

        public Portfolio()
        {

        }

        public Portfolio(string name, string description, decimal totalBalance, long customerId)
        {
            Name = name;
            Description = description;
            TotalBalance = totalBalance;
            CustomerId = customerId;
        }
    }
}
