using eCommerceXZ.Models.Models;
using System.Collections;

namespace eCommerceXZ.Data.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerByFilter(int customerId, string customerName, string customerEmail);
        Task<bool> CreateCustomer(Customer customer);
        Task<string> UpdateCustomer(Customer customer);
        Task<bool> DeleteCustomer(int CustomerId);        
    }
}
