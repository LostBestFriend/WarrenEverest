using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomersRepository _repository;

        public CustomersController(ICustomersRepository repository)
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(string cpf, Customer model)
        {
            int success = _repository.Update(cpf, model);
            switch (success)
            {
                case -1:
                    return BadRequest("O CPF ou E-mail utilizado já está em uso");
                case 0:
                    return NotFound($"Usuário não encontrado para o id: {cpf}");
                default:
                    return Ok();
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
