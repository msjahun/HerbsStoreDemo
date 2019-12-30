using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Core.Domain.Products;
using HerbsStore.Libraries.HS.Core.Domain.Users;

namespace HerbsStore.Libraries.HS.Core.Domain.Orders
{
    public class Order : BaseEntity
    {
        //list<products>
        //customerId
        public Order()
        {
            OrderProducts = new HashSet<OrderProducts>();
        }

        public ICollection<OrderProducts> OrderProducts { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public string Address { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool OrderStatus { get; set; } //true for confirm

        public bool PaymentType { get; set; }//true for credit cart, false for pay on delivery
        public string NameOnCard { get; set; }
        public string ExpiryDate { get; set; }
        public string Cvv { get; set; }
        public double TotalAmount { get; set; }

    }
}
