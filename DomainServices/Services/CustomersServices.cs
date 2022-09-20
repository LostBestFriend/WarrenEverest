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
            if (_repositoryFactory.Repository<Customer>().Any(customer => customer.Cpf == model.Cpf))
            {
                throw new ArgumentException("O Cpf informado já está em uso");
            }
            if (_repositoryFactory.Repository<Customer>().Any(customer => customer.Email == model.Email))
            {
                throw new ArgumentException("O Email informado já está em uso");
            }
            await _repositoryFactory.Repository<Customer>().AddAsync(model).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            return model.Id;
        }

        public async Task<Customer>? GetByIdAsync(long id)
        {
            var query = _repositoryFactory.Repository<Customer>().SingleResultQuery().AndFilter(customer => customer.Id == id);
            return await _repositoryFactory.Repository<Customer>().FirstOrDefaultAsync(query).ConfigureAwait(false);
        }

        public IEnumerable<Customer> GetAll()
        {
            var query = _repositoryFactory.Repository<Customer>().MultipleResultQuery();
            return _repositoryFactory.Repository<Customer>().Search(query);
        }

        public void Update(Customer model)
        {
            if (!_repositoryFactory.Repository<Customer>().Any(customer => customer.Id == model.Id))
            {
                throw new ArgumentNullException($"Cliente não encontrado para o id: {model.Id}");
            }
            if (_repositoryFactory.Repository<Customer>().Any(customer => customer.Cpf == model.Cpf))
            {
                throw new ArgumentException("O Cpf informado já está em uso");
            }
            if (_repositoryFactory.Repository<Customer>().Any(customer => customer.Email == model.Email))
            {
                throw new ArgumentException("O Email informado já está em uso");
            }

            _repositoryFactory.Repository<Customer>().Update(model);
            _unitOfWork.SaveChanges();
        }

        public void Delete(long id)
        {
            if (!_repositoryFactory.Repository<Customer>().Any(customr => customr.Id == id))
            {
                throw new ArgumentNullException($"Cliente não encontrado para o id: {id}");
            }

            _repositoryFactory.Repository<Customer>().Remove(customertoRemove => customertoRemove.Id == id);
            _unitOfWork.SaveChanges();
        }
    }
}
