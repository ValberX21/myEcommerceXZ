using eCommerceXZ.Data.Interfaces;
using eCommerceXZ.Data.Repository;
using eCommerceXZ.Models.Dtos;
using eCommerceXZ.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceXZ.Business.Validation
{
    public class ProductValidator : IProductValidator
    {
        private readonly ProductRepository _productRepository;
        protected ResponseDto _response;

        public ProductValidator(ProductRepository productRepository, ResponseDto response)
        {
            _productRepository = productRepository;
            _response = response;
        }

        public async Task<ResponseDto> deleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> listAllProducts()
        {
            try
            {
                return await _productRepository.listAllProducts();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> searchProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> updateCustomer(Product product)
        {
            throw new NotImplementedException();
        }

        public string ValidateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
