﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceXZ.Models.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; } 

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; } 

        [Required]
        public int Quantity { get; set; } 

        [Required]
        public decimal Price { get; set; } 

        public Product Product { get; set; } 

        public Order Order { get; set; } 
    }
}
