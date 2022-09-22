namespace AppModels.Mapper
{
    public class UpdatePortfolio
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalBalance { get; set; }
        public long CustomerId { get; set; }
    }
}
