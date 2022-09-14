using AppModels.Mapper;
using AutoMapper;
using DomainModels.Models;

namespace AppModels.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<Customer, CustomerResultDto>();
            CreateMap<CustomerUpdateDto, Customer>();
        }
    }
}
