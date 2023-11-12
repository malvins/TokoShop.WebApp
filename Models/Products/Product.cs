﻿using System.ComponentModel.DataAnnotations;

namespace TokoShop.WebApp.Models.Products
{
    public class Product
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
