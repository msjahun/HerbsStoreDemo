using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Core.Domain.Products;

namespace HerbsStore.Libraries.HS.Core.Domain.Orders
{
    public class Order : BaseEntity
    {
        //list<products>
        //customerId
        public Order()
        {
            Products = new HashSet<Product>();
        }

        public ICollection<Product> Products{ get; set; }

        public string UserId { get; set; }
        public string Address { get; set; }
        public DateTime CreatedOn { get; set; }
        public int OrderStatus { get; set; }
    }
}
