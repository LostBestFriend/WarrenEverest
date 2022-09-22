using AppModels.Mapper;
using AppServices.Interfaces;
using AutoMapper;
using DomainModels.Models;
using DomainServices.Interfaces;

namespace AppServices.Services
{
    public class CustomerAppServices : ICustomerAppServices
    {
        private readonly ICustomerServices _customerServices;
        private readonly IMapper _mapper;
        private readonly ICustomerBankInfoAppServices _customerBankInfoAppServices;

        public CustomerAppServices(ICustomerServices services, IMapper mapper, ICustomerBankInfoAppServices bankInfoAppServices)
        {
            _customerServices = services ?? throw new ArgumentNullException(nameof(services));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _customerBankInfoAppServices = bankInfoAppServices ?? throw new ArgumentNullException(nameof(bankInfoAppServices));
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
            long customerId = await _customerServices.CreateAsync(customerModel).ConfigureAwait(false);
            _customerBankInfoAppServices.Create(customerId);
            return customerId;
        }

        public void Update(long id, UpdateCustomer model)
        {
            Customer customerModel = _mapper.Map<Customer>(model);
            customerModel.Id = id;
            _customerServices.Update(customerModel);
        }

        public void Delete(long id)
        {
            _customerServices.Delete(id);
        }
    }
}
