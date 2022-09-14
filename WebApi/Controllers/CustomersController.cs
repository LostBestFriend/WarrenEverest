using AppServices.Services;
using DomainModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerAppServices _repository;

        public CustomersController(ICustomerAppServices repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var customer = _repository.GetById(id);
            if (customer is null)
            {
                return NotFound($"Usuário não encontrado para o id: {id}");
            }
            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(Customer model)
        {
            bool success = _repository.Create(model);
            if (success)
            {
                return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
            }
            return BadRequest("O CPF ou E-mail utilizado já está em uso");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(long id, Customer model)
        {
            try
            {
                _repository.Update(id, model);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            bool success = _repository.Delete(id);
            if (success)
            {
                return Ok();
            }
            return NotFound($"Usuário não encontrado para o id: {id}");
        }
    }
}
