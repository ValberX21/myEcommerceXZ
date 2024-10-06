using eCommerceXZ.Business.Validation;
using eCommerceXZ.Models.Dtos;
using eCommerceXZ.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceXZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerValidator _customerValidator;
        protected ResponseDto _response;

        public CustomerController(CustomerValidator customerValidator, ResponseDto responseDto)
        {
            _customerValidator = customerValidator;
            _response = responseDto;
        }

        [HttpGet("listCustomers")]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Customer> result = (List<Customer>)await _customerValidator.listAllCustomers();    
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch(Exception ex)
            {
                return Problem($"An error occurred: {ex.Message}");
            }
           
        }

        [HttpPost("addCustomer")]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            try
            {
                ResponseDto result = await _customerValidator.addCustomer(customer);

                var statusRetorned = result.GetType().GetProperty("IsSuccess")?.GetValue(result);

                if (statusRetorned.ToString() != "true")
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status201Created, result);
                }
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("updateCustomer")]
        public async Task<IActionResult> updateCustomer([FromBody] Customer customer)
        {
            try
            {
                ResponseDto result  = await _customerValidator.searchCustomer(customer);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch(Exception ex)
            {
                return Problem($"An error occurred: {ex.Message}");
            }            
        }

        [HttpGet("{id}")]
        public IActionResult Put(int id, [FromBody] Customer value)
        {
            return Ok("Update Customer");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("Delete Customer");
        }
    }
}
