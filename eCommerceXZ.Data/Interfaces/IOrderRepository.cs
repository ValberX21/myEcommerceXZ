using eCommerceXZ.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceXZ.Data.Interfaces
{
    public interface IOrderRepository
    {
        Task<bool> CreateOrder(Order order);
        Task<List<Dictionary<int,string>>> CheckProducts(List<OrderItem> Itens);
    }
}
