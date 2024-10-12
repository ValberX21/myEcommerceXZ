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

        public async Task<bool> CreateProduct(Product product)
        {
            try
            {
                var custom =  _db.Products.Add(product);
                _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var product = await _db.Products.FindAsync(productId);

                if (product == null)
                {
                    throw new Exception("Product not found.");
                }

                _db.Products.Remove(product);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Product> GetProductByFilter(int productId)
        {
            throw new NotImplementedException();
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

        public async Task<string> UpdateProduct(Product product)
        {
            string rquery = "";
            try
            {
                _db.Products.Update(product);
                await _db.SaveChangesAsync();
                rquery = "Product Updated";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rquery;
        }
    }
}
