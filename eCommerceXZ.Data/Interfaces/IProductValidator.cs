using eCommerceXZ.Models.Dtos;
using eCommerceXZ.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceXZ.Data.Interfaces
{
    public interface IProductValidator
    {
        string ValidateProduct(Product product);
        Task<IEnumerable<Product>> listAllProducts();
        Task<ResponseDto> updateCustomer(Product product);
        Task<Product> searchProduct(int productId);
        Task<ResponseDto> deleteProduct(int productId);
    }
}
