using AppModels.Mapper;
using AutoMapper;
using DomainModels.Models;
using DomainServices.Repositories;

namespace AppServices.Services
{
    public class CustomerAppServices : ICustomerAppServices
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerAppServices(ICustomerRepository repository, IMapper mapper)
        {
            _customerRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<CustomerResultDto> GetAll()
        {
            var result = _customerRepository.GetAll();
            return _mapper.Map<IEnumerable<CustomerResultDto>>(result);
        }

        public async Task<CustomerResultDto>? GetById(int id)
        {
            var result = await _customerRepository.GetById(id);
            return _mapper.Map<CustomerResultDto>(result);
        }

        public async Task<long> Create(CustomerCreateDto model)
        {
            Customer customerModel = _mapper.Map<Customer>(model);
            return await _customerRepository.Create(customerModel);
        }

        public async Task<CustomerResultDto>? GetByCpf(string cpf)
        {
            var result = await _customerRepository.GetByCpf(cpf);
            return _mapper.Map<CustomerResultDto>(result);
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
