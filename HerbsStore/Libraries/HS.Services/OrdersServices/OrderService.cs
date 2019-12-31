using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using HerbsStore.Libraries.HS.Core.Domain.Orders;
using HerbsStore.Libraries.HS.Core.Domain.Products;
using HerbsStore.Libraries.HS.Core.Domain.Users;
using HerbsStore.Libraries.HS.Data.Repository;
using Microsoft.AspNetCore.Identity;

namespace HerbsStore.Libraries.HS.Services.OrdersServices
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _ordersRepo;
        private readonly IRepository<Product> _productsRepo;
        private readonly IRepository<OrderProducts> _orderedProductsRepo;
        private readonly UserManager<User> _userManager;

        public OrderService(IRepository<Order> ordersRepo,
            IRepository<OrderProducts> orderedProductsRepo,
            IRepository<Product> productsRepo,
            UserManager<User> userManager)
        {
            _ordersRepo = ordersRepo;
            _orderedProductsRepo = orderedProductsRepo;
            _productsRepo = productsRepo;
            _userManager = userManager;
        }


        public bool OrderConfirmationToggle(long id)
        {
            var order = _ordersRepo.GetById(id);
            if (order == null) return false;

            order.OrderStatus = !order.OrderStatus;
            _ordersRepo.Update(order);
            return true;
        }
        
        public void DeleteOrder(long id)
        {
            var order = _ordersRepo.GetById(id);
            if (order == null) return;

            _ordersRepo.Delete(order);
        }


        public List<OrderCrudVm> GetOrders()
        {
            var model = from or in _ordersRepo.List()
                select new OrderCrudVm
                {
                    Id = or.Id,
                    CustomerName = GetCustomerName(or.UserId),
                    Address = GetUserAddress(or.UserId),
                    Products = GetOrderedProducts(or.Id),
                    CreatedOn = or.CreatedOn.ToString(CultureInfo.InvariantCulture),
                    OrderStatus = or.OrderStatus,
                    TotalAmount = or.TotalAmount

                };

            return model.ToList();
        }

        //three methods, one for getting a list of all products associated with an order
        //one for getting customer name,
        //one for getting customer address.

        private IEnumerable<orderedProducts> GetOrderedProducts(long orderId)
        {

            var model = from _orPr in _orderedProductsRepo.List()
                join prod in _productsRepo.List() on _orPr.ProductId equals prod.Id
                where _orPr.OrderId == orderId
                select new orderedProducts
                {
                    ProductName = prod.ProductName,
                    ImageUrl = prod.ImageUrl,
                    Quantity = _orPr.Quantity,
                    Id = prod.Id
                };

            return model;
        }

        private string GetUserAddress(string userId)
        {

            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);

            return user?.ParmanentAddress;
        }

        private string GetCustomerName(string userId)
        {

            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return null;

            return user.FirstName + " " + user.LastName;
        }
      
    }

    public class orderedProducts
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

        public int Quantity { get; set; }
        public long Id { get; set; }
    }
    public class OrderCrudVm
    {
        public long Id { get; set; }
        public IEnumerable<orderedProducts> Products { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string CreatedOn { get; set; }
        public bool OrderStatus { get; set; }
        public double TotalAmount { get; set; }
    }
}
