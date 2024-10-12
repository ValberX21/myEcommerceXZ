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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;
        protected ResponseDto _response;
        
        public OrderRepository(ApplicationDbContext db, ResponseDto response)
        {
            _db = db;
            _response = response;
        }

        public async Task<List<Dictionary<int, string>>> CheckProducts(List<OrderItem> Itens)
        {

            List<Dictionary<int, string>> existProducts = new List<Dictionary<int, string>>();

            foreach (OrderItem i in Itens)
            {
                var product =  _db.Products.Where(x => x.ProductId == i.ProductId).FirstOrDefault();

                if (product == null)
                {
                    throw new Exception("Product not found");
                }
                else
                {
                    if (product.StockQuantity >= i.Quantity)
                    {
                        existProducts.Add(new Dictionary<int, string> { { product.ProductId, product.Name } });
                    }
                    else
                    {
                        existProducts.Add(new Dictionary<int, string> { { product.ProductId, "Have no in stock" } });
                    }
                }
            }

            return existProducts;
        }

        public async Task<Customer> checkCustomer(int customerId)
        {
            Customer cust = new Customer();
            try
            {
                return cust = await _db.Customer.FindAsync(customerId);
               
            }
            catch (Exception ex)
            {
                throw new Exception("");  
            }
        }

        public async Task<bool> CreateOrder(Order order)
        {
            try
            {
                var custom = await _db.Orders.AddAsync(order);
                _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            List<Order> resultQuery = new List<Order>();

            try
            {
                resultQuery = await _db.Orders.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultQuery;
        }

    }
}
