using AppModels.Mapper.Order;
using AppServices.Interfaces;
using AutoMapper;
using DomainModels.Models;
using DomainServices.Interfaces;

namespace AppServices.Services
{
    public class OrderAppServices : IOrderAppServices
    {
        private readonly IOrderServices _orderServices;
        private readonly IMapper _mapper;

        public OrderAppServices(IMapper mapper, IOrderServices orderServices)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _orderServices = orderServices ?? throw new ArgumentNullException(nameof(orderServices));
        }

        public Task<long> CreateAsync(CreateOrder model)
        {
            Order order = _mapper.Map<Order>(model);
            return _orderServices.CreateAsync(order);
        }

        public IEnumerable<OrderResult> GetAll()
        {
            var result = _orderServices.GetAll();
            return _mapper.Map<IList<OrderResult>>(result);
        }

        public async Task<OrderResult> GetByIdAsync(long id)
        {
            var result = await _orderServices.GetByIdAsync(id);
            return _mapper.Map<OrderResult>(result);
        }

        public int GetAvailableQuotes(long portfolioId, long productId)
        {
            return _orderServices.GetAvailableQuotes(portfolioId, productId);
        }

        public IEnumerable<OrderResult> GetOrdersToExecute()
        {
            var orders = _orderServices.GetOrdersToExecute();

            return _mapper.Map<IEnumerable<OrderResult>>(orders);
            
        }

        public void Update(long id, UpdateOrder model)
        {
            Order order = _mapper.Map<Order>(model);
            _orderServices.Update(order);
        }

        public void Delete(long id)
        {
            _orderServices.Delete(id);
        }
    }
}
