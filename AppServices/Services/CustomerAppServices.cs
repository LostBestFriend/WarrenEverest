using DomainModels.Models;
using DomainServices.Services;

namespace AppServices.Services
{
    public class CustomerAppServices : ICustomerAppServices
    {
        private readonly ICustomersServices _customerServices;

        public CustomerAppServices(ICustomersServices customerServices)
        {
            _customerServices = customerServices ?? throw new ArgumentNullException(nameof(customerServices));
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

        public void Update(long id, Customer model)
        {
            _customerServices.Update(id, model);
        }

        public bool Delete(int id)
        {
            return _customerServices.Delete(id);
        }
    }
}
