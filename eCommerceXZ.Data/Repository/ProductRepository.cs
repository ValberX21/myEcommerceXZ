using eCommerceXZ.Data.Data;
using eCommerceXZ.Data.Interfaces;
using eCommerceXZ.Models.Dtos;
using eCommerceXZ.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceXZ.Data.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationDbContext _db;
        protected ResponseDto _response;

        public ProductRepository(ApplicationDbContext db, ResponseDto response)
        {
            _db = db;
            _response = response;
        }

        public async Task<IEnumerable<Product>> listAllProducts()
        {
            List<Product> resultQuery = new List<Product>();

            try
            {
                resultQuery = await _db.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultQuery;
        }
    }
}
