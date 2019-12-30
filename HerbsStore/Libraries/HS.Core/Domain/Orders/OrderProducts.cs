using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Core.Domain.Products;

namespace HerbsStore.Libraries.HS.Core.Domain.Orders
{
    public class OrderProducts:BaseEntity
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
