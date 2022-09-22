using AppModels.Mapper;
using DomainModels.Models;

namespace AppServices.Interfaces
{
    public interface IOrderAppServices
    {
        IEnumerable<Order> GetAll();
        Task<Order>? GetByIdAsync(long id);
        Task<long> CreateAsync(CreateOrder model);
        void Update(long id, UpdateOrder model);
        void Delete(long id);
    }
}
