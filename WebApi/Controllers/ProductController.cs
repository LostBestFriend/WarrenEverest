using AppModels.Mapper;
using AppServices.Interfaces;
using DomainModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppServices _repository;

        public ProductController(IProductAppServices repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var product = await _repository.GetByIdAsync(id).ConfigureAwait(false);
            if (product is null)
            {
                return NotFound($"Produto não encontrado para o id {id}");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateProduct model)
        {
            long productId = await _repository.CreateAsync(model);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = productId }, productId);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, UpdateProduct model)
        {
            try
            {
                _repository.Update(id, model);
                return Ok();
            }
            catch (ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            try
            {
                _repository.Delete(id);
                return Ok();
            }
            catch(ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }
            catch(Exception exception)
            {
                return Problem(exception.Message);
            }
        }
    }
}
