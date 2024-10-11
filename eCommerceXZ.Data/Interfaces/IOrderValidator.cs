using eCommerceXZ.Models.Dtos;
using eCommerceXZ.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceXZ.Data.Interfaces
{
    public interface IOrderValidator
    {
        Task<string> ValidateOrder(Order order);
        Task<IEnumerable<Order>> listAllOrders();
        Task<ResponseDto> updateOrder(Order order);
        Task<Order> searchOrder(int orderId);
        Task<ResponseDto> deleteOrder(int OrderId);
    }
}
