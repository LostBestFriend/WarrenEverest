using AppModels.Mapper;
using AutoMapper;
using DomainModels.Models;

namespace AppModels.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerCreate, Customer>();
            CreateMap<Customer, CustomerResult>();
            CreateMap<CustomerUpdate, Customer>();
        }
    }
}
