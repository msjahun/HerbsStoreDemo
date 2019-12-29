using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Core.Domain.Products;

namespace HerbsStore.Libraries.HS.Core.Domain.Orders
{
    public class Cart : BaseEntity
    {
        //product id //use to get product image, price, name
        //userId //use to know who ordered what and when
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
       public DateTime CreatedOn { get; set; }
    }
}
