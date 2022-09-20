using DomainModels.ExtensionMethods;
using DomainModels.Models;
using EntityFrameworkCore.Repository.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data.Context;

namespace DomainServices.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Customer> _customerRepository;

        public CustomerRepository(IUnitOfWork<WarrenEverestContext> unitOfWork, IRepositoryFactory<WarrenEverestContext> repository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repositoryFactory = repository ?? (IRepositoryFactory)_unitOfWork;
            _customerRepository = _repositoryFactory.Repository<Customer>();
        }

        public async Task<long> Create(Customer model)
        {
            if (_customerRepository.Any(customer => customer.Cpf == model.Cpf || customer.Email == model.Email))
            {
                throw new ArgumentException("O Cpf ou Email já está em uso");
            }
            await _customerRepository.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return model.Id;
        }

        public async Task<Customer>? GetById(long id)
        {
            var query = _customerRepository.SingleResultQuery().AndFilter(customer => customer.Id == id);
            return await _customerRepository.FirstOrDefaultAsync(query);
        }

        public IEnumerable<Customer> GetAll()
        {
            var query = _customerRepository.MultipleResultQuery();
            return _customerRepository.Search(query);
        }

        public async Task<Customer?> GetByCpf(string cpf)
        {
            cpf.FormatString();
            var query = _customerRepository.SingleResultQuery().AndFilter(customer => customer.Cpf == cpf);
            return await _customerRepository.FirstOrDefaultAsync(query);
        }

        public void Update(Customer model)
        {
            if (!_customerRepository.Any(customer => customer.Id == model.Id)) throw new ArgumentNullException($"Cliente não encontrado para o id: {model.Id}");

            if (_customerRepository.Any(customer => (customer.Cpf == model.Cpf || customer.Email == model.Email) && customer.Id != model.Id))
            {
                throw new ArgumentException("Cpf ou Email informado já está em uso");
            }
            _customerRepository.Update(model);
            _unitOfWork.SaveChanges();
        }

        public void Delete(long id)
        {
            if (!_customerRepository.Any(customr => customr.Id == id))
            {
                throw new ArgumentNullException($"Cliente não encontrado para o id: {id}");
            }

            _customerRepository.Remove(customertoRemove => customertoRemove.Id == id);
            _unitOfWork.SaveChanges();
        }
    }
}
