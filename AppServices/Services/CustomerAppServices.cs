using AppModels.Mapper;
using AutoMapper;
using DomainModels.Models;
using DomainServices.Services;

namespace AppServices.Services
{
    public class CustomerAppServices : ICustomerAppServices
    {
        private readonly ICustomerServices _customerServices;
        private readonly IMapper _mapper;

        public CustomerAppServices(ICustomerServices services, IMapper mapper)
        {
            _customerServices = services ?? throw new ArgumentNullException(nameof(services));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<CustomerResult> GetAll()
        {
            var result = _customerServices.GetAll();
            return _mapper.Map<IEnumerable<CustomerResult>>(result);
        }

        public async Task<CustomerResult>? GetByIdAsync(long id)
        {
            var result = await _customerServices.GetByIdAsync(id).ConfigureAwait(false);
            return _mapper.Map<CustomerResult>(result);
        }

        public async Task<long> CreateAsync(CreateCustomer model)
        {
            Customer customerModel = _mapper.Map<Customer>(model);
            return await _customerServices.CreateAsync(customerModel).ConfigureAwait(false);
        }

        public void Update(long id, UpdateCustomer model)
        {
            Customer customerModel = _mapper.Map<Customer>(model);
            customerModel.Id = id;
            _customerServices.Update(customerModel);
        }

        public void Delete(int id)
        {
            _customerServices.Delete(id);
        }
    }
}
