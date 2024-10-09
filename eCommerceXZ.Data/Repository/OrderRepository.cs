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
