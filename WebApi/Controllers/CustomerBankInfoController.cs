using AppServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerBankInfoController : ControllerBase
    {
        private readonly ICustomerBankInfoAppServices _customerBankInfoAppServices;

        public CustomerBankInfoController(ICustomerBankInfoAppServices customerBankInfoAppServices)
        {
            _customerBankInfoAppServices = customerBankInfoAppServices ?? throw new ArgumentNullException(nameof(customerBankInfoAppServices));
        }

        [HttpGet("{customerId}")]
        public IActionResult GetAccountBalance(long customerId)
        {
            try
            {
                decimal accountBalance = _customerBankInfoAppServices.GetBalance(customerId);
                return Ok(accountBalance);
            }
            catch (ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }

        [HttpPatch("{customerId}/deposit")]
        public IActionResult Deposit(long customerId, decimal amount)
        {
            try
            {
                _customerBankInfoAppServices.Deposit(customerId, amount);
                return Ok();
            }
            catch (ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }

        [HttpPatch("{customerId}/withdraw")]
        public IActionResult Withdraw(long customerId, decimal amount)
        {
            try
            {
                _customerBankInfoAppServices.Withdraw(customerId, amount);
                return Ok();
            }
            catch (ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }
    }
}
