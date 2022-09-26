namespace DomainModels.Models
{
    public class PortfolioProduct
    {
        public long PortfolioId { get; set; }
        public long ProductId { get; set; }

        public PortfolioProduct(long portfolioId, long productId)
        {
            PortfolioId = portfolioId;
            ProductId = productId;
        }
    }
}
