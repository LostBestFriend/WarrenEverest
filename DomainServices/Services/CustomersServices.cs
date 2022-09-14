using DomainModels.ExtensionMethods;
using DomainModels.Models;

namespace DomainServices.Services
{
    public class CustomersServices : ICustomersServices
    {
        private readonly List<Customer> _customerList = new();

        public bool Create(Customer model)
        {
            if (_customerList.Any(customer => customer.Cpf == model.Cpf || customer.Email == model.Email)) return false;

            model.Id = _customerList.Count + 1;
            _customerList.Add(model);
            return true;
        }

        public Customer? GetById(int id)
        {
            return _customerList.FirstOrDefault(customer => customer.Id == id);
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

        public void Update(Customer model)
        {
            int index = _customerList.FindIndex(customer => customer.Id == model.Id);

            if (index == -1) throw new ArgumentException($"Usuário não encontrado para o id: {model.Id}");

            if(_customerList.Any(customer => (customer.Cpf == model.Cpf || customer.Email == model.Email) && customer.Id != model.Id))
            {
                throw new ArgumentException("CPf ou Email informado já está em uso");
            }
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
