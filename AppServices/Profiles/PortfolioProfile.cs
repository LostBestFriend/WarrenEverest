using AppModels.Mapper.Portfolio;
using AutoMapper;
using DomainModels.Models;

namespace AppServices.Profiles
{
    public class PortfolioProfile : Profile
    {
        public PortfolioProfile()
        {
            CreateMap<Portfolio, PortfolioResult>();
            CreateMap<CreatePortfolio, Portfolio>();
            CreateMap<UpdatePortfolio, Portfolio>();
        }
    }
}
