using AppModels.Mapper;

namespace AppServices.Services
{
    public interface ICustomerAppServices
    {
        Task<long> CreateAsync(CreateCustomer model);
        void Delete(int id);
        IEnumerable<CustomerResult> GetAll();
        Task<CustomerResult>? GetByIdAsync(long id);
        void Update(long id, UpdateCustomer model);
    }
}