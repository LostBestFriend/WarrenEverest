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

        public CustomerAppServices(ICustomersServices customerServices,IMapper mapper)
        {
            _customerServices = customerServices;
            _mapper = mapper;
        }

        public List<CustomerResultDto> GetAll()
        {
            var result =_customerServices.GetAll();
            return _mapper.Map<List<CustomerResultDto>>(result);
        }

        public CustomerResultDto? GetById(int id)
        {
            var result = _customerServices.GetById(id);
            return _mapper.Map<CustomerResultDto>(result);
        }

        public bool Create(CustomerCreateDto model)
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
            model.Id = id;
            Customer customerModel = _mapper.Map<Customer>(model);
            _customerServices.Update(customerModel);
        }

        public bool Delete(int id)
        {
            return _customerServices.Delete(id);
        }
    }
}
