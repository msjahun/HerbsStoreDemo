using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Core.Domain.Products;
using HerbsStore.Libraries.HS.Core.Domain.Users;

namespace HerbsStore.Libraries.HS.Core.Domain.Orders
{
    public class Cart : BaseEntity
    {
        //product id //use to get product image, price, name
        //userId //use to know who ordered what and when
        public Cart()
        {
            CartProducts = new HashSet<CartProducts>();
        }

        public ICollection<CartProducts> CartProducts{ get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int Quantity { get; set; }
       public DateTime CreatedOn { get; set; }
    }
}
