using DomainModels.Models;

namespace AppServices.Services
{
    public interface ICustomerAppServices
    {
        bool Create(Customer model);
        bool Delete(int id);
        List<Customer> GetAll();
        Customer? GetByCpf(string cpf);
        Customer? GetById(int id);
        void Update(long id, Customer model);
    }
}