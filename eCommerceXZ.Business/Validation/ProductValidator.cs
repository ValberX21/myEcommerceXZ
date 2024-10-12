using eCommerceXZ.Data.Interfaces;
using eCommerceXZ.Data.Repository;
using eCommerceXZ.Models.Dtos;
using eCommerceXZ.Models.Models;
using Microsoft.IdentityModel.Tokens;
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

        public async Task<ResponseDto> addProduct(Product product)
        {
            if (ValidateProduct(product) == "")
            {
                try
                {
                    bool addProdcut = await _productRepository.CreateProduct(product);

                    if (addProdcut)
                    {
                        _response.IsSuccess = true;
                        _response.Result = "Product added success";
                    }
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.Result = ex.Message;
                }
            }
            else
            {
                _response.IsSuccess = false;
                _response.Result = ValidateProduct(product);
            }

            return _response;
        }

        public async Task<ResponseDto> deleteProduct(int productId)
        {
            try
            {
                bool resultQ = await _productRepository.DeleteProduct(productId);

                if (resultQ)
                {
                    _response.IsSuccess = true;
                    _response.Result = "Product deleted";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _response;
        }

        public async Task<Product> searchProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> updateProduct(Product product)
        {
            try
            {
                string resultQ = await _productRepository.UpdateProduct(product);

                if (!resultQ.IsNullOrEmpty())
                {
                    _response.IsSuccess = true;
                    _response.Result = "Product updated";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _response;
        }

        public string ValidateProduct(Product product)
        {
            return string.Empty;
            //throw new NotImplementedException();
        }

    }
}
