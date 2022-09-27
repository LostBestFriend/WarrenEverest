namespace AppServices.Interfaces
{
    public interface IPortfolioProductAppServices
    {
        void CreateRelation(long portfolioId, long productId);
        void DeleteRelation(long portfolioId, long productId);
        bool RelationExists(long portfolioId, long productId);
    }
}
