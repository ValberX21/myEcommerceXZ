using eCommerceXZ.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceXZ.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> listAllProducts();
    }
}
