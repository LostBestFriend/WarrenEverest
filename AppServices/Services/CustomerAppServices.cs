using AppModels.Mapper;
using AutoMapper;
using DomainModels.Models;
using DomainServices.Services;

namespace AppServices.Services
{
    public class CustomerAppServices : ICustomerAppServices
    {
        private readonly ICustomerServices _customerRepository;
        private readonly IMapper _mapper;

        public CustomerAppServices(ICustomerServices repository, IMapper mapper)
        {
            _customerRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<CustomerResultDto> GetAll()
        {
            var result = _customerRepository.GetAll();
            return _mapper.Map<IEnumerable<CustomerResultDto>>(result);
        }

        public async Task<CustomerResultDto>? GetByIdAsync(long id)
        {
            var result = await _customerRepository.GetByIdAsync(id).ConfigureAwait(false);
            return _mapper.Map<CustomerResultDto>(result);
        }

        public async Task<long> CreateAsync(CustomerCreateDto model)
        {
            Customer customerModel = _mapper.Map<Customer>(model);
            return await _customerRepository.CreateAsync(customerModel).ConfigureAwait(false);
        }

        public void Update(long id, CustomerUpdateDto model)
        {
            Customer customerModel = _mapper.Map<Customer>(model);
            customerModel.Id = id;
            _customerRepository.Update(customerModel);
        }

        public void Delete(int id)
        {
            _customerRepository.Delete(id);
        }
    }
}
