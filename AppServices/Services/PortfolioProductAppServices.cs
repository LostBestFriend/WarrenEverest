using AppServices.Interfaces;
using DomainServices.Interfaces;

namespace AppServices.Services
{
    public class PortfolioProductAppServices : IPortfolioProductAppServices
    {
        private readonly IPortfolioProductServices _portfolioProductServices;

        public PortfolioProductAppServices(IPortfolioProductServices portfolioProductServices)
        {
            _portfolioProductServices = portfolioProductServices ?? throw new ArgumentNullException(nameof(portfolioProductServices));
        }

        public void CreateRelation(long portfolioId, long productId)
        {
            _portfolioProductServices.CreateRelation(portfolioId, productId);
        }

        public void DeleteRelation(long portfolioId, long productId)
        {
            _portfolioProductServices.DeleteRelation(portfolioId, productId);
        }

        public bool RelationExists(long portfolioId, long productId)
        {
            return _portfolioProductServices.RelationExists(portfolioId, productId);
        }     
    }
}
