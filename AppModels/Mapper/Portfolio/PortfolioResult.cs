using AppModels.Mapper.Customer;
using AppModels.Mapper.Order;
using AppModels.Mapper.Product;

namespace AppModels.Mapper.Portfolio
{
    public class PortfolioResult
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalBalance { get; set; }
        public CustomerResult Customer { get; set; }
        public long CustomerId { get; set; }
        public IList<ProductResult> Products { get; set; } = new List<ProductResult>();
        public IList<OrderResult> Orders { get; set; } = new List<OrderResult>();
    }
}
