using eCommerceXZ.Models.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceXZ.Data.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int ProductId);
        Task<IEnumerable<Product>> CreateProduct(Product product);
        Task<IEnumerable<Product>> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int ProductId);
    }
}
