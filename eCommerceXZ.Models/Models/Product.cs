﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceXZ.Models.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; } 

        [Required]
        public string Name { get; set; } 

        public string Description { get; set; } 

        [Required]
        public decimal Price { get; set; } 

        public int StockQuantity { get; set; } 

        public string ImageUrl { get; set; } 
    }
}
