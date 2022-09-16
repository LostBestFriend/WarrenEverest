using DomainModels.Models;

namespace DomainServices.Services
{
    public interface ICustomersServices
    {
        IEnumerable<Customer> GetAll();
        Customer? GetById(int id);
        long Create(Customer model);
        Customer? GetByCpf(string cpf);
        void Update(long id, Customer model);
        void Delete(int id);
    }
}