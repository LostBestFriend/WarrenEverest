using AppModels.Mapper;
using AutoMapper;
using DomainModels.Models;

namespace AppServices.Profiles
{
    public class PortfolioProfile : Profile
    {
        public PortfolioProfile()
        {
            CreateMap<CreatePortfolio, Portfolio>();
            CreateMap<UpdatePortfolio, Portfolio>();

        }
    }
}
