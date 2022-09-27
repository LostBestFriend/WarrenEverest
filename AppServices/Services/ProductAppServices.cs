using AppModels.Mapper.Product;
using AppServices.Interfaces;
using AutoMapper;
using DomainModels.Models;
using DomainServices.Interfaces;

namespace AppServices.Services
{
    public class ProductAppServices : IProductAppServices
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public ProductAppServices(IMapper mapper, IProductServices productServices)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productServices = productServices ?? throw new ArgumentNullException(nameof(productServices));
        }
        public IEnumerable<ProductResult> GetAll()
        {
            var result = _productServices.GetAll();
            return _mapper.Map<IEnumerable<ProductResult>>(result);
        }

        public async Task<ProductResult> GetByIdAsync(long id)
        {
            var result = await _productServices.GetByIdAsync(id);
            return _mapper.Map<ProductResult>(result);
        }

        public async Task<long> CreateAsync(CreateProduct model)
        {
            Product product = _mapper.Map<Product>(model);
            return await _productServices.CreateAsync(product);
        }

        public void Update(long productId, UpdateProduct model)
        {
            Product product = _mapper.Map<Product>(model);
            product.Id = productId;
            _productServices.Update(product);
        }

        public void Delete(long id)
        {
            _productServices.Delete(id);
        }
    }
}
