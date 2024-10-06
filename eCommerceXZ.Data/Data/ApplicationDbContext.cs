using eCommerceXZ.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceXZ.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
        }

        public DbSet<Customer> Customer { get; set; } // Make sure to match your DbSet name to your model
        
    }
}
