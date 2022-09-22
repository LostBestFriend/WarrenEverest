using DomainModels.Models;
using DomainServices.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data.Context;

namespace DomainServices.Services
{
    public class PortfolioServices : IPortfolioServices
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IUnitOfWork _unitOfWork;

        public PortfolioServices(IUnitOfWork<WarrenEverestContext> unitOfWork, IRepositoryFactory<WarrenEverestContext> repository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repositoryFactory = repository ?? (IRepositoryFactory)_unitOfWork;
        }

        public async Task<long> CreateAsync(Portfolio model)
        {
            var repository = _unitOfWork.Repository<Portfolio>();
            await repository.AddAsync(model).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return model.Id;
        }

        public IEnumerable<Portfolio> GetAll()
        {
            var repository = _repositoryFactory.Repository<Portfolio>();
            var query = repository.MultipleResultQuery();
            return repository.Search(query);
        }

        public void Invest(decimal amount, long productId)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(decimal amount, long productId)
        {
            throw new NotImplementedException();
        }
    }
}
