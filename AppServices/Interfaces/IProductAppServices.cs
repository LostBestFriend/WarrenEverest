using AppModels.Mapper;
using DomainModels.Models;

namespace AppServices.Interfaces
{
    public interface IProductAppServices
    {
        IEnumerable<Product> GetAll();
        Task<Product>? GetByIdAsync(long id);
        Task<long> CreateAsync(CreateProduct model);
        void Update(long id, UpdateProduct model);
        void Delete(long id);
    }
}
