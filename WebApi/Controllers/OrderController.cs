using AppModels.Mapper;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppServices _repository;

        public OrderController(IOrderAppServices repository)
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
            var order = await _repository.GetByIdAsync(id);
            if(order is null)
            {
                return NotFound($"Ordem de Investimento não encontrada para o id: {id}");
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateOrder model)
        {
            long orderId = await _repository.CreateAsync(model);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = orderId }, orderId);
        }

        [HttpPut]
        public IActionResult Update (long id, UpdateOrder model)
        {
            try
            {
                _repository.Update(id, model);
                return Ok();
            } catch(ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            } catch(Exception exception)
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
            catch (ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }
    }
}
