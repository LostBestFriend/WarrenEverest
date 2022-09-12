using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private ICustomersRepository _repository;
        CustomerValidator validator = new CustomerValidator();


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

            Customer? customer = _repository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(Customer model)
        {
            ValidationResult result = validator.Validate(model);
            bool doesNotExists = _repository.DoesNotExists(model);

            if (result.IsValid && doesNotExists)
            {
                _repository.Create(model);
                return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
            }
            else if (!result.IsValid)
            {
                string allErrors = result.ToString("-");
                return BadRequest(allErrors);
            }
            return BadRequest("O CPF ou E-mail já está em uso.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(string cpf, Customer model)
        {
            bool doesNotExists = _repository.DoesNotExists(model);
            bool success = _repository.Update(cpf, model);
            if (success)
            {
                return Ok();
            }
            return NotFound();
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
            return NotFound();
        }
    }
}
