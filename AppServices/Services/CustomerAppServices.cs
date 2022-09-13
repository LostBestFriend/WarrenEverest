using DomainModels.Models;
using DomainServices.Services;

namespace AppServices.Services
{
    public class CustomerAppServices : ICustomerAppServices
    {
        private readonly ICustomersServices _customerServices;

        public CustomerAppServices(ICustomersServices customerServices)
        {
            _customerServices = customerServices;
        }

        public List<Customer> GetAll()
        {
            return _customerServices.GetAll();
        }

        public Customer? GetById(int id)
        {
            return _customerServices.GetById(id);
        }

        public bool Create(Customer model)
        {
            return _customerServices.Create(model);
        }

        public bool AlreadyExists(Customer model)
        {
            return _customerServices.AlreadyExists(model);
        }

        public bool AlreadyExistsUpdate(Customer model, long id)
        {
            return _customerServices.AlreadyExistsUpdate(model, id);
        }

        public Customer? GetByCpf(string cpf)
        {
            return _customerServices.GetByCpf(cpf);
        }

        public int Update(string cpf, Customer model)
        {
            return _customerServices.Update(cpf, model);
        }

        public bool Delete(int id)
        {
            return _customerServices.Delete(id);
        }
    }
}
