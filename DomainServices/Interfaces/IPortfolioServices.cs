using DomainModels.Models;

namespace DomainServices.Interfaces
{
    public interface IPortfolioServices
    {
        Task<long> CreateAsync(Portfolio model);
        IEnumerable<Portfolio> GetAll();
        void Invest(decimal amount, long productId);
        void Withdraw(decimal amount, long productId);
    }
}
