using AppModels.Mapper;
using DomainModels.Models;

namespace AppServices.Interfaces
{
    public interface IPortfolioAppServices
    {
        Task<long> CreateAsync(CreatePortfolio model);
        IEnumerable<Portfolio> GetAll();
        void Invest(decimal amount, long productId);
        void Withdraw(decimal amount, long productId);
    }
}
