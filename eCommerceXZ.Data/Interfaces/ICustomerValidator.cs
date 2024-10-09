using eCommerceXZ.Models.Dtos;
using eCommerceXZ.Models.Models;

namespace eCommerceXZ.Data.Interfaces
{
    public interface ICustomerValidator
    {
         string ValidateCustomer(Customer customer);
         Task<IEnumerable<Customer>> listAllCustomers();
         Task<ResponseDto> updateCustomer(Customer customer);
         Task<Customer> searchCustomer(int customerId, string customerName, string customerEmail);
         Task<ResponseDto> deleteCustomer(int customerId);
    }
}
