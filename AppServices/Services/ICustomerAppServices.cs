using AppModels.Mapper;

namespace AppServices.Services
{
    public interface ICustomerAppServices
    {
        Task<long> Create(CustomerCreateDto model);
        void Delete(int id);
        IEnumerable<CustomerResultDto> GetAll();
        Task<CustomerResultDto>? GetByCpf(string cpf);
        Task<CustomerResultDto>? GetById(int id);
        void Update(long id, CustomerUpdateDto model);
    }
}