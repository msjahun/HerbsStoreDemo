using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerbsStore.Libraries.HS.Core.Domain.Products
{
    public class Product : BaseEntity
    {

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

    }
}
