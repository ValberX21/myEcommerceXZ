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

                bool statusReturned = (bool)result.GetType().GetProperty("IsSuccess")?.GetValue(result);

                if (!statusReturned)
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
                ResponseDto result  = await _customerValidator.updateCustomer(customer);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch(Exception ex)
            {
                return Problem($"An error occurred: {ex.Message}");
            }            
        }

        [HttpGet("searchCustomer")]
        public async Task<IActionResult> Get(int customerID, string customerName,string customerEmail)
        {
            try
            {
                Customer result = await _customerValidator.searchCustomer(customerID,customerName,customerEmail);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                ResponseDto result = await _customerValidator.deleteCustomer(id);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred: {ex.Message}");
            }
        }
    }
}
