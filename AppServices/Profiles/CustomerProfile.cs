using AppModels.Mapper;
using AutoMapper;
using DomainModels.Models;

namespace AppModels.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomer, Customer>();
            CreateMap<Customer, CustomerResult>();
            CreateMap<UpdateCustomer, Customer>();
        }
    }
}
