using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceXZ.Models.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; } // Unique identifier for the order

        [Required]
        public int CustomerId { get; set; } // Foreign key to the Customer entity

        public DateTime OrderDate { get; set; } = DateTime.UtcNow; // The date when the order was created

        public DateTime? ShipDate { get; set; } // Optional: Date when the order was shipped

        [Required]
        public string Status { get; set; } = "Pending"; // Order status, e.g., Pending, Shipped, Delivered

        [Required]
        public decimal TotalAmount { get; set; } // Total amount of the order

        public List<OrderItem> OrderItems { get; set; } // List of items in the order

        public string ShippingAddress { get; set; } // Address where the order is shipped

        public string PaymentMethod { get; set; } // E.g., Credit Card, PayPal, etc.
    }
}
