using DomainModels.Models;

namespace AppServices.Services
{
    public interface ICustomerAppServices
    {
        bool AlreadyExistsUpdate(Customer model, long id);
        bool Create(Customer model);
        bool Delete(int id);
        List<Customer> GetAll();
        Customer? GetByCpf(string cpf);
        Customer? GetById(int id);
        void Update(long id, Customer model);
    }
}