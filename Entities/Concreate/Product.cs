﻿using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public int Reting { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public bool  IsFeatured { get; set; }
        public List<ProductHomeListDTO> ProductHomeListDTO { get; set; }
        public List<ProductLanguage> ProductLanguages { get; set; }
        public List<CategoryLanguage> CategoryLanguages { get; set; }
        public List<Picture> Pictures { get; set; }
    }
}
