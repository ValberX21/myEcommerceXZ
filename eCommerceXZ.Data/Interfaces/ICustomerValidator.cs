using eCommerceXZ.Models.Dtos;
using eCommerceXZ.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceXZ.Data.Interfaces
{
    public interface ICustomerValidator
    {
        public string ValidateCustomer(Customer customer);
        public Task<IEnumerable<Customer>> listAllCustomers();
        public Task<ResponseDto> searchCustomer(Customer customer);

    }
}
