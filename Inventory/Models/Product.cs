﻿using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Product
    {
        [Key]
        public int Id_Product { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}
