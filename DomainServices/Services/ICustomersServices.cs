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
        void Update(long id, Customer model);
        bool Delete(int id);
    }
}