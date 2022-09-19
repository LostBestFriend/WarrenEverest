using DomainModels.ExtensionMethods;
using DomainModels.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainServices.Services
{
    public class CustomersServices : ICustomersServices
    {
        private readonly WarrenEverestContext _warrenEverestContext;

        public CustomersServices(WarrenEverestContext warrenEverestContext)
        {
            _warrenEverestContext = warrenEverestContext ?? throw new ArgumentNullException(nameof(warrenEverestContext));
        }

        public long Create(Customer model)
        {
            var customers = _warrenEverestContext.Set<Customer>();

            if (customers.Any(customer => customer.Cpf == model.Cpf || customer.Email == model.Email))
            {
                throw new ArgumentException("O Cpf ou Email já está em uso");
            }
            customers.Add(model);
            _warrenEverestContext.SaveChanges();
            return model.Id;
        }

        public Customer? GetById(int id)
        {
            return _warrenEverestContext.Set<Customer>().FirstOrDefault(customer => customer.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _warrenEverestContext.Set<Customer>();
        }

        public Customer? GetByCpf(string cpf)
        {
            cpf.FormatString();
            return _warrenEverestContext.Set<Customer>().FirstOrDefault(customer => customer.Cpf == cpf);
        }

        public void Update(Customer model)
        {
            var customers = _warrenEverestContext.Set<Customer>();
            if (!customers.Any(customer => customer.Id == model.Id)) throw new ArgumentNullException($"Cliente não encontrado para o id: {model.Id}");

            if (customers.Any(customer => (customer.Cpf == model.Cpf || customer.Email == model.Email) && customer.Id != model.Id))
            {
                throw new ArgumentException("Cpf ou Email informado já está em uso");
            }
            _warrenEverestContext.Set<Customer>().Update(model);
            _warrenEverestContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Customer? customertoRemove = _warrenEverestContext.Set<Customer>().FirstOrDefault(customer => customer.Id == id);
            if (customertoRemove is null)
            {
                throw new ArgumentNullException($"Cliente não encontrado para o id: {id}");
            }
            _warrenEverestContext.Set<Customer>().Remove(customertoRemove).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _warrenEverestContext.SaveChanges();
        }
    }
}
