using DomainModels.ExtensionMethods;
using DomainModels.Models;

namespace DomainServices.Services
{
    public class CustomersServices : ICustomersServices
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
            cpf.FormatString();
            return _customerList.FirstOrDefault(customer => customer.Cpf == cpf);
        }

        public void Update(long id, Customer model)
        {
            int index = _customerList.FindIndex(customer => customer.Id == id);

            if (index == -1) throw new ArgumentException($"Cpf ou E-mail já está em uso. Email: {model.Email}, Cpf: {model.Cpf}");
            bool alreadyExist = AlreadyExistsUpdate(model, _customerList[index].Id);

            if (alreadyExist) throw new ArgumentNullException($"Usuário não encontrado para o id: {id}");

            model.Id = _customerList[index].Id;
            _customerList[index] = model;
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
