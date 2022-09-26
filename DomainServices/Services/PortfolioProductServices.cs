using DomainModels.Models;
using DomainServices.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data.Context;

namespace DomainServices.Services
{
    public class PortfolioProductServices : IPortfolioProductServices
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IUnitOfWork _unitOfWork;

        public PortfolioProductServices(IUnitOfWork<WarrenEverestContext> unitOfWork, IRepositoryFactory<WarrenEverestContext> repository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repositoryFactory = repository ?? (IRepositoryFactory)_unitOfWork;
        }
        public void CreateRelation(long portfolioId, long productId)
        {
            var repository = _unitOfWork.Repository<PortfolioProduct>();

            repository.Add(new PortfolioProduct(portfolioId, productId));
            _unitOfWork.SaveChanges();
        }

        public void DeleteRelation(long portfolioId, long productId)
        {
            var repository = _unitOfWork.Repository<PortfolioProduct>();

            repository.Remove(new PortfolioProduct(portfolioId, productId));
            _unitOfWork.SaveChanges();
        }

        public bool RelationExists(long portfolioId, long productId)
        {
            var repository = _repositoryFactory.Repository<PortfolioProduct>();

            return repository.Any(portfolioproduct => portfolioproduct.PortfolioId == portfolioId && portfolioproduct.ProductId == productId);
        }
    }
}
