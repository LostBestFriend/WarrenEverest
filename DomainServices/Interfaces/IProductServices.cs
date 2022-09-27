using DomainModels.Models;

namespace DomainServices.Interfaces
{
    public interface IProductServices
    {
        IEnumerable<Product> GetAll();
        Task<Product> GetByIdAsync(long id);
        Task<long> CreateAsync(Product model);
        void Update(Product model);
        void AddPortfolio(long productId, long portfolioId);
        void Delete(long id);
    }
}
