using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceXZ.Models.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; } // Assuming this will be the primary key

        [Required]
        [StringLength(100, ErrorMessage = "Customer name cannot exceed 100 characters.")]
        public string CustomerName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [StringLength(150, ErrorMessage = "Customer email cannot exceed 150 characters.")]
        public string CustomerEmail { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(20, ErrorMessage = "Customer phone cannot exceed 20 characters.")]
        public string CustomerPhone { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Customer address cannot exceed 200 characters.")]
        public string CustomerAddress { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Customer city cannot exceed 100 characters.")]
        public string CustomerCity { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Customer state cannot exceed 50 characters.")]
        public string CustomerState { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Customer ZIP code cannot exceed 10 characters.")]
        public string CustomerZip { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Customer country cannot exceed 100 characters.")]
        public string CustomerCountry { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Customer password cannot exceed 255 characters.")]
        public string CustomerPassword { get; set; }

        public string CustomerToken { get; set; }

        [StringLength(50, ErrorMessage = "Customer role cannot exceed 50 characters.")]
        public string? CustomerRole { get; set; }

        [Required]
        public bool CustomerActive { get; set; }

        [Required]
        public DateTime CustomerCreated { get; set; } = DateTime.Now;

        public DateTime CustomerModified { get; set; } = DateTime.Now;
    }
}
