using AppModels.Mapper;
using DomainModels.Models;

namespace AppServices.Services
{
    public interface ICustomerAppServices
    {
        long Create(CustomerCreateDto model);
        bool Delete(int id);
        List<CustomerResultDto> GetAll();
        CustomerResultDto? GetByCpf(string cpf);
        CustomerResultDto? GetById(int id);
        void Update(long id, CustomerUpdateDto model);
    }
}