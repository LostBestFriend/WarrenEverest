using AppModels.Mapper;
using AutoMapper;
using DomainModels.Models;
using DomainServices.Services;

namespace AppServices.Services
{
    public class CustomerAppServices : ICustomerAppServices
    {
        private readonly ICustomersServices _customerServices;
        private readonly IMapper _mapper;

        public CustomerAppServices(ICustomersServices customerServices, IMapper mapper)
        {
            _customerServices = customerServices ?? throw new ArgumentNullException(nameof(customerServices));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public List<CustomerResultDto> GetAll()
        {
            var result = _customerServices.GetAll();
            return _mapper.Map<List<CustomerResultDto>>(result);
        }

        public CustomerResultDto? GetById(int id)
        {
            var result = _customerServices.GetById(id);
            return _mapper.Map<CustomerResultDto>(result);
        }

        public long Create(CustomerCreateDto model)
        {
            Customer customerModel = _mapper.Map<Customer>(model);
            return _customerServices.Create(customerModel);
        }

        public CustomerResultDto? GetByCpf(string cpf)
        {
            var result = _customerServices.GetByCpf(cpf);
            return _mapper.Map<CustomerResultDto>(result);
        }

        public void Update(long id, CustomerUpdateDto model)
        {
            Customer customerModel = _mapper.Map<Customer>(model);
            _customerServices.Update(id, customerModel);
        }

        public void Delete(int id)
        {
            _customerServices.Delete(id);
        }
    }
}
