using AppModels.Mapper;

namespace AppServices.Interfaces
{
    public interface ICustomerAppServices
    {
        Task<long> CreateAsync(CreateCustomer model);
        IEnumerable<CustomerResult> GetAll();
        Task<CustomerResult>? GetByIdAsync(long id);
        void Update(long id, UpdateCustomer model);
        void Delete(long id);
    }
}