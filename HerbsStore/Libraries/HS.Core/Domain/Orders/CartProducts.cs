using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Core.Domain.Products;

namespace HerbsStore.Libraries.HS.Core.Domain.Orders
{
    public class CartProducts:BaseEntity
    {
        public long CartId { get; set; }
        public Cart Cart { get; set; }
        public int Quantity { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
