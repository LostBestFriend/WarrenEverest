using AppModels.Mapper;
using AppServices.Interfaces;
using DomainModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioAppServices _repository;

        public PortfolioController(IPortfolioAppServices repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var portolios = _repository.GetAll();
            return Ok(portolios);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreatePortfolio model)
        {
            long repositoryId = await _repository.CreateAsync(model);
            return Ok(repositoryId);
        }

    }
}
