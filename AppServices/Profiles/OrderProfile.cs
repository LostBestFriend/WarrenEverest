using AppModels.Mapper;
using AutoMapper;
using DomainModels.Models;

namespace AppServices.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrder, Order>();
            CreateMap<UpdateOrder, Order>();
        }
    }
}
