using DomainModels.ExtensionMethods;
using DomainModels.Models;
using Infrastructure.Data.Context;

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
            if (_warrenEverestContext.Customer.Any(customer => customer.Cpf == model.Cpf || customer.Email == model.Email))
            {
                throw new ArgumentException("O Cpf ou Email já está em uso");
            }
            _warrenEverestContext.Customer.Add(model);
            _warrenEverestContext.SaveChanges();
            return model.Id;
        }

        public Customer? GetById(int id)
        {
            return _warrenEverestContext.Customer.FirstOrDefault(customer => customer.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _warrenEverestContext.Customer.ToList();
        }

        public Customer? GetByCpf(string cpf)
        {
            cpf.FormatString();
            return _warrenEverestContext.Customer.FirstOrDefault(customer => customer.Cpf == cpf);
        }

        public void Update(long id, Customer model)
        {
            if (!_warrenEverestContext.Customer.Any(customer => customer.Id == id)) throw new ArgumentNullException($"Cliente não encontrado para o id: {id}");

            if (_warrenEverestContext.Customer.Any(customer => (customer.Cpf == model.Cpf || customer.Email == model.Email) && customer.Id != id))
            {
                throw new ArgumentException("CPf ou Email informado já está em uso");
            }
            model.Id = id;
            _warrenEverestContext.Customer.Update(model);
            _warrenEverestContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Customer? customertoRemove = _warrenEverestContext.Customer.FirstOrDefault(customer => customer.Id == id);
            if (customertoRemove is null)
            {
                throw new ArgumentException($"Cliente não encontrado para o id: {id}");
            }
            _warrenEverestContext.Customer.Remove(customertoRemove).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _warrenEverestContext.SaveChanges();
        }
    }
}
