using DomainModels.Models;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data.Context;

namespace DomainServices.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerServices(IUnitOfWork<WarrenEverestContext> unitOfWork, IRepositoryFactory<WarrenEverestContext> repository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repositoryFactory = repository ?? (IRepositoryFactory)_unitOfWork;
        }

        public async Task<long> CreateAsync(Customer model)
        {
            var repository = _unitOfWork.Repository<Customer>();
            if (repository.Any(customer => customer.Cpf == model.Cpf))
            {
                throw new ArgumentException("O Cpf informado já está em uso");
            }
            if (repository.Any(customer => customer.Email == model.Email))
            {
                throw new ArgumentException("O Email informado já está em uso");
            }
            await repository.AddAsync(model).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            return model.Id;
        }

        public async Task<Customer>? GetByIdAsync(long id)
        {
            var repository = _unitOfWork.Repository<Customer>();

            var query = repository.SingleResultQuery().AndFilter(customer => customer.Id == id);

            var customer = await repository.FirstOrDefaultAsync(query).ConfigureAwait(false);
            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            var repository = _unitOfWork.Repository<Customer>();

            var query = repository.MultipleResultQuery();

            return repository.Search(query);
        }

        public void Update(Customer model)
        {
            var repository = _unitOfWork.Repository<Customer>();

            if (!repository.Any(customer => customer.Id == model.Id))
            {
                throw new ArgumentNullException($"Cliente não encontrado para o id: {model.Id}");
            }
            if (repository.Any(customer => customer.Cpf == model.Cpf))
            {
                throw new ArgumentException("O Cpf informado já está em uso");
            }
            if (repository.Any(customer => customer.Email == model.Email))
            {
                throw new ArgumentException("O Email informado já está em uso");
            }

            repository.Update(model);
            _unitOfWork.SaveChanges();
        }

        public void Delete(long id)
        {
            var repository = _unitOfWork.Repository<Customer>();

            if (!repository.Any(customr => customr.Id == id))
            {
                throw new ArgumentNullException($"Cliente não encontrado para o id: {id}");
            }

            repository.Remove(customertoRemove => customertoRemove.Id == id);
            _unitOfWork.SaveChanges();
        }
    }
}
