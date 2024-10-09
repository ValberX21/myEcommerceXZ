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
        string ValidateOrder(Order customer);
        Task<IEnumerable<Order>> listAllOrders();
        Task<ResponseDto> updateCustomer(Order order);
        Task<Order> searchOrder(int orderId);
        Task<ResponseDto> deleteOrder(int OrderId);
    }
}
