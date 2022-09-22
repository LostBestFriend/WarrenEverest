using DomainModels.Models;

namespace DomainServices.Interfaces
{
    public interface IProductServices
    {
        IEnumerable<Product> GetAll();
        Task<Product>? GetByIdAsync(long id);
        Task<long> CreateAsync(Product model);
        void Update(Product model);
        void Delete(long id);
    }
}
