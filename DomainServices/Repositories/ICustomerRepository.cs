using DomainModels.Models;
using EntityFrameworkCore.Repository.Interfaces;

namespace DomainServices.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Task<Customer>? GetById(long id);
        Task<long> Create(Customer model);
        void Update(Customer model);
        Task<Customer?> GetByCpf(string cpf);
        void Delete(long id);
    }
}