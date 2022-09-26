using AppModels.Mapper.Order;
using AutoMapper;
using DomainModels.Models;

namespace AppServices.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderResult>();
            CreateMap<CreateOrder, Order>();
            CreateMap<UpdateOrder, Order>();
        }
    }
}
