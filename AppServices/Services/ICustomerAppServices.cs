using DomainModels.Models;

namespace AppServices.Services
{
    public interface ICustomerAppServices
    {
        bool AlreadyExists(Customer model);
        bool AlreadyExistsUpdate(Customer model, long id);
        bool Create(Customer model);
        bool Delete(int id);
        List<Customer> GetAll();
        Customer? GetByCpf(string cpf);
        Customer? GetById(int id);
        int Update(string cpf, Customer model);
    }
}