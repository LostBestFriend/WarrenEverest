using AppModels.Mapper;
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

        public IEnumerable<Order> GetAll()
        {
            return _orderServices.GetAll();
        }

        public Task<Order>? GetByIdAsync(long id)
        {
            return _orderServices.GetByIdAsync(id);
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
