using AppModels.Mapper;
using AutoMapper;
using DomainModels.Models;

namespace AppServices.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProduct, Product>();
            CreateMap<UpdateProduct, Product>();
        }
    }
}
