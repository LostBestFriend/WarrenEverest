using AppModels.Mapper;

namespace AppServices.Services
{
    public interface ICustomerAppServices
    {
        Task<long> CreateAsync(CustomerCreate model);
        void Delete(int id);
        IEnumerable<CustomerResult> GetAll();
        Task<CustomerResult>? GetByIdAsync(long id);
        void Update(long id, CustomerUpdate model);
    }
}