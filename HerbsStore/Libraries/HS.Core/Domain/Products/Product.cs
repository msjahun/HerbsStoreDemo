﻿using System;
using System.Collections.Generic;
using HerbsStore.Libraries.HS.Core.Domain.Diseases;
using HerbsStore.Libraries.HS.Core.Domain.Orders;

namespace HerbsStore.Libraries.HS.Core.Domain.Products
{
    public class Product : BaseEntity
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProducts>();
            CartProducts = new HashSet<CartProducts>();
            ProductDiseases = new HashSet<ProductDisease>();
        }
        public string ProductName { get; set; }
        public int ProductType { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
      
        public string Description { get; set; }
        public string Feature { get; set; }
        public string PrimaryCare { get; set; }
        public string SecondaryCare { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedOn { get; set; }

        public ICollection<OrderProducts> OrderProducts { get; set; }
        public ICollection<CartProducts> CartProducts{ get; set; }
        public ICollection<ProductDisease> ProductDiseases{ get; set; }

    }
}
