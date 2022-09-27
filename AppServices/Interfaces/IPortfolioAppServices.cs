using AppModels.Mapper.Order;
using AppModels.Mapper.Portfolio;

namespace AppServices.Interfaces
{
    public interface IPortfolioAppServices
    {
        Task<long> CreateAsync(CreatePortfolio model);
        IEnumerable<PortfolioResult> GetAll();
        Task<PortfolioResult> GetByIdAsync(long id);
        decimal GetBalance(long portfolioId);
        void Deposit(decimal amount, long customerId, long portfolioId);
        void Withdraw(decimal amount, long customerId, long portfolioId);
        void ExecuteTodaysOrders();
        void ExecuteBuyOrder(OrderResult order);
        void ExecuteSellOrder(OrderResult order);
        Task InvestAsync(int quotes, DateTime liquidateAt, long productId, long portfolioId);
        Task UninvestAsync(int quotes, DateTime liquidateAt, long productId, long portfolioId);
        void Delete(long portfolioId);
    }
}
