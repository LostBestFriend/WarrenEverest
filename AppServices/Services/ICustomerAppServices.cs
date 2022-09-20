using AppModels.Mapper;

namespace AppServices.Services
{
    public interface ICustomerAppServices
    {
        Task<long> CreateAsync(CreateCustomer model);
        void Delete(int id);
        IEnumerable<ResultCustomer> GetAll();
        Task<ResultCustomer>? GetByIdAsync(long id);
        void Update(long id, UpdateCustomer model);
    }
}