using DomainModels.Models;
using DomainServices.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainServices.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IUnitOfWork _unitOfWork;

        public OrderServices(IUnitOfWork<WarrenEverestContext> unitOfWork, IRepositoryFactory<WarrenEverestContext> repository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repositoryFactory = repository ?? (IRepositoryFactory)_unitOfWork;
        }

        public async Task<long> CreateAsync(Order model)
        {
            var repository = _unitOfWork.Repository<Order>();
            await repository.AddAsync(model).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return model.Id;
        }

        public IEnumerable<Order> GetAll()
        {
            var repository = _repositoryFactory.Repository<Order>();

            var query = repository.MultipleResultQuery();

            return repository.Search(query);
        }

        public async Task<Order> GetByIdAsync(long id)
        {
            var repository = _repositoryFactory.Repository<Order>();

            var query = repository.SingleResultQuery()
                                   .AndFilter(order => order.Id == id)
                                   .Include(source => source.Include(order => order.Product).Include(order => order.Portfolio));

            var order = await repository.FirstOrDefaultAsync(query).ConfigureAwait(false);

            return order;
        }

        public IList<Order> GetOrdersToExecute()
        {
            var repository = _unitOfWork.Repository<Order>();

            var query = repository.MultipleResultQuery().AndFilter(order => order.LiquidateAt.Date == DateTime.Now.Date);

            var orders = repository.Search(query);

            return orders;
        }

        public void Update(Order model)
        {
            var repository = _unitOfWork.Repository<Order>();

            repository.Update(model);
            _unitOfWork.SaveChanges();
        }

        public void Delete(long id)
        {
            var repository = _repositoryFactory.Repository<Order>();

            if (!repository.Any(order => order.Id == id))
            {
                throw new ArgumentNullException($"Não encontrada nenhuma Ordem de Investimento com o id: {id}");
            }

            repository.Remove(order => order.Id == id);
        }

        public int GetAvailableQuotes(long portfolioId, long productId)
        {
            var repository = _repositoryFactory.Repository<Order>();

            var query = repository.MultipleResultQuery().AndFilter(order => order.ProductId == productId);

            var allOrders = repository.Search(query);

            if(allOrders.Count() == 0)
            {
                throw new ArgumentNullException($"Nenhuma cota disponível para o produto de Id: {productId} na carteira de Id {portfolioId}");
            }

            int availableQuotes = 0;

            foreach(var order in allOrders)
            {
                if(order.Direction == OrderDirection.Buy)
                {
                    availableQuotes += order.Quotes;
                }
                else
                {
                    availableQuotes -= order.Quotes;
                }
            }

            return availableQuotes;
        }
    }
}
