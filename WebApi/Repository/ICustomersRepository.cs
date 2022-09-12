using WebApi.Models;

namespace WebApi.Repository
{
    public interface ICustomersRepository
    {
        List<Customer> GetAll();
        Customer? GetById(int id);
        void Create(Customer model);
        bool DoesNotExists(Customer model);
        Customer? GetByCpf(string cpf);
        bool Update(string cpf, Customer model);
        bool Delete(int id);



    }
}