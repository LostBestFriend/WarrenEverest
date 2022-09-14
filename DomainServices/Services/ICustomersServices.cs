using DomainModels.Models;

namespace DomainServices.Services
{
    public interface ICustomersServices
    {
        List<Customer> GetAll();
        Customer? GetById(int id);
        bool Create(Customer model);
        Customer? GetByCpf(string cpf);
        void Update(Customer model);
        bool Delete(int id);
    }
}