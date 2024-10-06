using eCommerceXZ.Data.Interfaces;
using eCommerceXZ.Data.Repository;
using eCommerceXZ.Models.Dtos;
using eCommerceXZ.Models.Models;
using Microsoft.IdentityModel.Tokens;

namespace eCommerceXZ.Business.Validation
{
    public class CustomerValidator: ICustomerValidator
    {
        private readonly CustomerRepository _customerRepository;
        protected ResponseDto _response;
        public CustomerValidator(CustomerRepository customerRepository, ResponseDto response)
        {
            _customerRepository = customerRepository;
            _response = response;
        }

        public async Task<ResponseDto> addCustomer(Customer customer)
        {          
            if(ValidateCustomer(customer) == "")
            {
                try
                {
                    bool addCustomer = await _customerRepository.CreateCustomer(customer);

                    if (addCustomer)
                    {
                        _response.IsSuccess = true;
                        _response.Result = "Customer added success";
                    }                    
                }
                catch(Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.Result = ex.Message;
                }              
            }
            else
            {
                _response.IsSuccess = false;
                _response.Result = ValidateCustomer(customer);
            }            

            return _response;
        }

        public async Task<IEnumerable<Customer>> listAllCustomers()
        {
            try
            {
                 return await _customerRepository.GetCustomers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseDto> searchCustomer(Customer customer)
        {
            try
            {
                string resultQ =  await _customerRepository.UpdateCustomer(customer);

                if (!resultQ.IsNullOrEmpty())
                {
                    _response.IsSuccess = true;
                    _response.Result = "Customer updated";
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _response;
        }

        public string ValidateCustomer(Customer customer)
        {
            string message = "";

            if (customer.CustomerCity != "São Paulo")
            {
                message = "Erro mens - City unknown";
            }

            if (customer == null)
            {
                message = "Erro mens - Customer object is null !";
            }

            if (string.IsNullOrEmpty(customer.CustomerName))
            {
                message = "Erro mens - Customer object is null !";
            }

            if (string.IsNullOrEmpty(customer.CustomerEmail))
            {
                message = "Erro mens - Customer object is null !";
            }

            if (string.IsNullOrEmpty(customer.CustomerPhone))
            {
                message = "Erro mens - Customer object is null !";
            }

            return message;
        }
            
    }
}
