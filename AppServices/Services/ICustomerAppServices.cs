using AppModels.Mapper;

namespace AppServices.Services
{
    public interface ICustomerAppServices
    {
        Task<long> CreateAsync(CustomerCreateDto model);
        void Delete(int id);
        IEnumerable<CustomerResultDto> GetAll();
        Task<CustomerResultDto>? GetByIdAsync(long id);
        void Update(long id, CustomerUpdateDto model);
    }
}