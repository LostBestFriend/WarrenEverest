using AppModels.Mapper;
using AppServices.Interfaces;
using AutoMapper;
using DomainModels.Models;
using DomainServices.Interfaces;

namespace AppServices.Services
{
    public class PortfolioAppServices : IPortfolioAppServices
    {
        private readonly IPortfolioServices _portfolioServices;
        private readonly IMapper _mapper;

        public PortfolioAppServices(IPortfolioServices portfolio, IMapper mapper)
        {
            _portfolioServices = portfolio;
            _mapper = mapper;
        }

        public async Task<long> CreateAsync(CreatePortfolio model)
        {
            Portfolio portfolio = _mapper.Map<Portfolio>(model);
            return await _portfolioServices.CreateAsync(portfolio).ConfigureAwait(false);
        }

        public IEnumerable<Portfolio> GetAll()
        {
            return _portfolioServices.GetAll();
        }

        public void Invest(decimal amount, long productId)
        {
            _portfolioServices.Invest(amount, productId);
        }

        public void Withdraw(decimal amount, long productId)
        {
            _portfolioServices.Withdraw(amount, productId);
        }
    }
}
