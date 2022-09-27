using AppModels.Enums;

namespace AppModels.Mapper.Order
{
    public class CreateOrder
    {
        public int Quotes { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal NetValue { get; set; }
        public DateTime LiquidateAt { get; set; }
        public OrderDirection Direction { get; set; }
        public long ProductId { get; set; }
        public long PortfolioId { get; set; }

        public CreateOrder(int quotes, decimal unitPrice, decimal netValue, DateTime liquidateAt, OrderDirection direction, long productId, long portfolioId)
        {
            Quotes = quotes;
            UnitPrice = unitPrice;
            NetValue = netValue;
            LiquidateAt = liquidateAt;
            Direction = direction;
            ProductId = productId;
            PortfolioId = portfolioId;
        }
    }
}
