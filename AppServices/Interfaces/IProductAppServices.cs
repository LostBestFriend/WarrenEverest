using AppModels.Mapper.Product;

namespace AppServices.Interfaces
{
    public interface IProductAppServices
    {
        IEnumerable<ProductResult> GetAll();
        Task<ProductResult> GetByIdAsync(long id);
        Task<long> CreateAsync(CreateProduct model);
        void Update(long id, UpdateProduct model);
        void Delete(long id);
    }
}
