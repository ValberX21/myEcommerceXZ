using eCommerceXZ.Data.Data;
using eCommerceXZ.Data.Interfaces;
using eCommerceXZ.Models.Dtos;
using eCommerceXZ.Models.Models;
using Microsoft.EntityFrameworkCore;


namespace eCommerceXZ.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _db;
        protected ResponseDto _response;
        public CustomerRepository(ApplicationDbContext db, ResponseDto response)
        {
            _db = db;
            _response = response;
        }
        public async Task<bool> CreateCustomer(Customer customer)
        {            
            try
            {
                var custom = await _db.Customer.AddAsync(customer);
                 _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> DeleteCustomer(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerById(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            List<Customer> resultQuery = new List<Customer>();

            try
            {
                resultQuery = await _db.Customer.ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return resultQuery;
        }

        public async Task<string> UpdateCustomer(Customer customer)
        {
            string rquery = "";
            try
            {
                _db.Customer.Update(customer);
                await _db.SaveChangesAsync();
                rquery = "User Updated";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rquery;
        }
    }
}
