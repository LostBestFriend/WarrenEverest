using DomainModels.Models;

namespace DomainServices.Interfaces
{
    public interface IOrderServices
    {
        IEnumerable<Order> GetAll();
        Task<Order>? GetByIdAsync(long id);
        Task<long> CreateAsync(Order model);
        void Update(Order model);
        void Delete(long id);

    }
}
