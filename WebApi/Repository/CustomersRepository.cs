using WebApi.Models;

namespace WebApi.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly List<Customer> _customerList = new();

        public bool Create(Customer model)
        {
            bool alreadyExitst = AlreadyExists(model);
            if (alreadyExitst) return false;
            model.Id = _customerList.Count + 1;
            _customerList.Add(model);
            return true;
        }

        public Customer? GetById(int id)
        {
            return _customerList.FirstOrDefault(customer => customer.Id == id);
        }

        public bool AlreadyExists(Customer model)
        {
            return _customerList.Any(customer => customer.Cpf == model.Cpf || customer.Email == model.Email);
        }
        public bool AlreadyExistsUpdate(Customer model, long id)
        {
            return _customerList.Any(customer => (customer.Cpf == model.Cpf || customer.Email == model.Email) && customer.Id != id);
        }

        public List<Customer> GetAll()
        {
            return _customerList;
        }

        public Customer? GetByCpf(string cpf)
        {
            return _customerList.FirstOrDefault(customer => customer.Cpf == cpf);
        }

        public int Update(string Cpf, Customer model)
        {
            int index = _customerList.FindIndex(customer => customer.Cpf == Cpf);
            if (index == -1)
            {
                return 0;
            }
            bool alreadyExist = AlreadyExistsUpdate(model, _customerList[index].Id);
            if (alreadyExist) return -1;
            else
            {
                model.Id = _customerList[index].Id;
                _customerList[index] = model;
                return 1;
            }
        }

        public bool Delete(int id)
        {
            var customerToRemove = _customerList.FirstOrDefault(customer => customer.Id == id);
            if (customerToRemove is null) return false;
            _customerList.Remove(customerToRemove);
            return true;
        }
    }
}
