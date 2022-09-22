using AppModels.Mapper;
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

        public Task<long> CreateAsync(CreateProduct model)
        {
            Product product = _mapper.Map<Product>(model);
            return _productServices.CreateAsync(product);
        }

        public void Delete(long id)
        {
            _productServices.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productServices.GetAll();
        }

        public Task<Product>? GetByIdAsync(long id)
        {
            return _productServices.GetByIdAsync(id);
        }

        public void Update(long productId, UpdateProduct model)
        {
            Product product = _mapper.Map<Product>(model);
            product.Id = productId;
            _productServices.Update(product);
        }
    }
}
