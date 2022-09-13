using DomainModels.Models;

namespace DomainServices.Services
{
    public interface ICustomersServices
    {
        List<Customer> GetAll();
        Customer? GetById(int id);
        bool Create(Customer model);
        bool AlreadyExists(Customer model);
        public bool AlreadyExistsUpdate(Customer model, long id);
        Customer? GetByCpf(string cpf);
        int Update(string cpf, Customer model);
        bool Delete(int id);
    }
}