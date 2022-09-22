using DomainModels.Models;

namespace DomainServices.Interfaces
{
    public interface ICustomerServices
    {
        IEnumerable<Customer> GetAll();
        Task<Customer>? GetByIdAsync(long id);
        Task<long> CreateAsync(Customer model);
        void Update(Customer model);
        void Delete(long id);
    }
}