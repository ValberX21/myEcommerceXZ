using eCommerceXZ.Models.Models;
using System.Collections;

namespace eCommerceXZ.Data.Interfaces
{
    public interface IOrder
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrderById(int OrderId);
        Task<IEnumerable<Order>> CreateOrder(Order order);
        Task<IEnumerable<Order>> UpdateOrder(Order order);
        Task<bool> DeleteOrder(int OrderId);
    }
}
