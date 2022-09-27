using DomainModels.Models;

namespace DomainServices.Interfaces
{
    public interface IPortfolioServices
    {
        Task<long> CreateAsync(Portfolio model);
        IEnumerable<Portfolio> GetAll();
        Task<Portfolio> GetByIdAsync(long id);
        public decimal GetBalance(long portfolioId);
        void Deposit(decimal amount, long portfolioId);
        void Withdraw(decimal amount, long portfolioId);
        void Delete(long portfolioId);
    }
}
