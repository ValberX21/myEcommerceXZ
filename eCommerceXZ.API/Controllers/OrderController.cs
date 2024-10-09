using eCommerceXZ.Business.Validation;
using eCommerceXZ.Models.Dtos;
using eCommerceXZ.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceXZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderValidator _OrderValidator;
        protected ResponseDto _response;

        public OrderController(OrderValidator OrderValidator, ResponseDto responseDto)
        {
            _OrderValidator = OrderValidator;
            _response = responseDto;
        }

        [HttpGet("listOrders")]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Order> result = (List<Order>)await _OrderValidator.listAllOrders();
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addOrder")]
        public async Task<IActionResult> Post([FromBody] Order Order)
        {
            try
            {
                ResponseDto result = await _OrderValidator.addOrder(Order);

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

        [HttpPut("updateOrder")]
        public async Task<IActionResult> updateOrder([FromBody] Order Order)
        {
            return null;
            //try
            //{
            //    ResponseDto result = await _OrderValidator.updateOrder(Order);
            //    return StatusCode(StatusCodes.Status200OK, result);
            //}
            //catch (Exception ex)
            //{
            //    return Problem($"An error occurred: {ex.Message}");
            //}
        }

        [HttpGet("searchOrder")]
        public async Task<IActionResult> Get(int OrderID, string OrderName, string OrderEmail)
        {
            //try
            //{
            //    Order result = await _OrderValidator.searchOrder(OrderID, OrderName, OrderEmail);
            //    return StatusCode(StatusCodes.Status201Created, result);
            //}
            //catch (Exception ex)
            //{
            //    return Problem($"An error occurred: {ex.Message}");
            //}
            return null;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //try
            //{
            //    Order result = await _OrderValidator.deleteOrder(id);
            //    return StatusCode(StatusCodes.Status201Created, result);
            //}
            //catch (Exception ex)
            //{
            //    return Problem($"An error occurred: {ex.Message}");
            //}
            return null;
        }
    }
}
