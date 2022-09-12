using WebApi.Models;

namespace WebApi.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly List<Customer> _customerList = new();

        public void Create(Customer model)
        {
            model.Id = _customerList.Count + 1;
            _customerList.Add(model);
        }

        public Customer? GetById(int id)
        {
            return _customerList.FirstOrDefault(customer => customer.Id == id);
        }

        public bool DoesNotExists(Customer model)
        {
            Customer? doesNotExists = _customerList.FirstOrDefault(customer => customer.Cpf == model.Cpf || customer.Email == model.Email);
            if (doesNotExists is null)
            {
                return true;
            }
            return false;
        }

        public List<Customer> GetAll()
        {
            return _customerList;
        }

        public Customer? GetByCpf(string cpf)
        {
            return _customerList.FirstOrDefault(customer => customer.Cpf == cpf);

        }

        public bool Update(string Cpf, Customer model)
        {
            Customer? customerInList = _customerList.FirstOrDefault(customer => customer.Cpf == Cpf);
            if (customerInList is null)
            {
                return false;
            }
            else
            {
                int index = _customerList.IndexOf(customerInList);
                _customerList[index] = model;
                return true;
            }
        }

        public bool Delete(int id)
        {
            Customer? customerToRemove = _customerList.FirstOrDefault(customer => customer.Id == id);
            if (customerToRemove is null)
            {
                return false;
            }
            _customerList.Remove(customerToRemove);
            return true;
        }
    }
}
