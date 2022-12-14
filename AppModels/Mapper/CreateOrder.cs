
using AppModels.Enums;

namespace AppModels.Mapper
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
    }
}
