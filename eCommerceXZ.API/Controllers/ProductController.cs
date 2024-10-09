using eCommerceXZ.Business.Validation;
using eCommerceXZ.Data.Interfaces;
using eCommerceXZ.Models.Dtos;
using eCommerceXZ.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceXZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductValidator _productValidator;
        protected ResponseDto _response;

        public ProductController(ProductValidator productValidator, ResponseDto responseDto)
        {
            _productValidator = productValidator;
            _response = responseDto;
        }

        [HttpGet("listProducts")]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Product> result = (List<Product>)await _productValidator.listAllProducts();
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred: {ex.Message}");
            }
        }
    }
}
