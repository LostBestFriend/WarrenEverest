using DomainModels.ExtensionMethods;
using DomainModels.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainServices.Services
{
    public class CustomersServices : ICustomersServices
    {
        private readonly WarrenEverestContext _warrenEverestContext;

            
        private DbSet<Customer> _customers;

        public CustomersServices(WarrenEverestContext warrenEverestContext)
        {
            _warrenEverestContext = warrenEverestContext ?? throw new ArgumentNullException(nameof(warrenEverestContext));
            _customers = warrenEverestContext.Set<Customer>();
        }

        public long Create(Customer model)
        {

            if (_customers.Any(customer => customer.Cpf == model.Cpf || customer.Email == model.Email))
            {
                throw new ArgumentException("O Cpf ou Email já está em uso");
            }
            _customers.Add(model);
            _warrenEverestContext.SaveChanges();
            return model.Id;
        }

        public Customer? GetById(int id)
        {
            return _customers.FirstOrDefault(customer => customer.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        public Customer? GetByCpf(string cpf)
        {
            cpf.FormatString();
            return _customers.FirstOrDefault(customer => customer.Cpf == cpf);
        }

        public void Update(Customer model)
        {
            if (!_customers.Any(customer => customer.Id == model.Id)) throw new ArgumentNullException($"Cliente não encontrado para o id: {model.Id}");

            if (_customers.Any(customer => (customer.Cpf == model.Cpf || customer.Email == model.Email) && customer.Id != model.Id))
            {
                throw new ArgumentException("Cpf ou Email informado já está em uso");
            }
            _customers.Update(model);
            _warrenEverestContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var customertoRemove = _customers.FirstOrDefault(customer => customer.Id == id);
            if (customertoRemove is null)
            {
                throw new ArgumentNullException($"Cliente não encontrado para o id: {id}");
            }
            _customers.Remove(customertoRemove).State = EntityState.Deleted;
            _warrenEverestContext.SaveChanges();
        }
    }
}
