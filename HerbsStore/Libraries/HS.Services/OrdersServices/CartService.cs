using System;
using System.Collections.Generic;
using System.Linq;
using HerbsStore.Libraries.HS.Core.Domain.Orders;
using HerbsStore.Libraries.HS.Core.Domain.Products;
using HerbsStore.Libraries.HS.Data.Repository;
using HerbsStore.Libraries.HS.Services.Security;
using Remotion.Linq.Clauses;

namespace HerbsStore.Libraries.HS.Services.OrdersServices
{
    public class CartService : ICartService
    {
        private readonly IRepository<Cart> _cartRepo;
        private readonly IRepository<Core.Domain.Orders.CartProducts> _cartProducts;
        private readonly IPermissionService _permissionService;
        private readonly IRepository<Product> _productRepo;

        public CartService(IRepository<Cart> cartRepo,
            IRepository<Core.Domain.Orders.CartProducts> cartProductRepo,
            IPermissionService permissionService,
            IRepository<Product> productRepo)
        {
            _cartRepo = cartRepo;
            _cartProducts = cartProductRepo;
            _permissionService = permissionService;
            _productRepo = productRepo;
        }

        private Cart GetCurrentCart()
        {
            //get current cart using user Id
            var currentUser = _permissionService.GetCurrentUser();

            if (currentUser == null) return null;
            var cart = _cartRepo.List().FirstOrDefault(c => c.UserId == currentUser.Id);

            return cart;

        }
        public bool AddProductToCart(long productId)
        {
            //add to the cart with userId and quantity 1
            var product = _productRepo.GetById(productId);
            if (product ==  null) return false;


            //check if cart for userExists,
            var cart = GetCurrentCart();
           
           if (cart != null)
            { //yes exists, then add product,
          
                //check if product exist

                var existProduct = _cartProducts.List()
                    .FirstOrDefault(c => c.CartId == cart.Id && c.ProductId == product.Id);

                if (existProduct != null) return true;

                var cartProduct = new Core.Domain.Orders.CartProducts
                {
                    CartId = cart.Id,
                    ProductId = product.Id,
                    Quantity = 1
                };

                _cartProducts.Insert(cartProduct);
            }
            else
            {
                //no doesn't exist, then create the cart, and put the userId and the product'
                var currentUser = _permissionService.GetCurrentUser();
                if (currentUser == null) return false;

                var newCart = new Cart
                {
                    UserId = currentUser.Id,
                    Quantity = 1,
                    CreatedOn = DateTime.Now,
                   
                };

              var cartId =  _cartRepo.Insert(newCart);


              var existProduct = _cartProducts.List()
                  .FirstOrDefault(c => c.CartId == cartId && c.ProductId == product.Id);

              if (existProduct != null) return true;

                var cartProduct = new Core.Domain.Orders.CartProducts
              {
                  CartId = cartId,
                  ProductId = productId
              };

              _cartProducts.Insert(cartProduct);
            }



            return true;
        }


        public bool AddQuantityToCart(long productId)
        {

            //get product from cart and add to quantity

            var cart = GetCurrentCart();
            if (cart == null) return false;

            var cartProduct = _cartProducts.List().FirstOrDefault(c => c.CartId == cart.Id && c.ProductId == productId);
            if (cartProduct == null) return false;

            cartProduct.Quantity = cartProduct.Quantity + 1;

            _cartProducts.Update(cartProduct);
            return true;
        }


        public bool SubtractQuantityToCart(long productId)
        {
            //subtract from product quantity -1
            var cart = GetCurrentCart();
            if (cart == null) return false;

            var cartProduct = _cartProducts.List().FirstOrDefault(c => c.CartId == cart.Id && c.ProductId== productId);
            if (cartProduct == null) return false;

            if (cartProduct.Quantity > 1) { 
                cartProduct.Quantity = cartProduct.Quantity - 1;

                _cartProducts.Update(cartProduct);
            }

            return true;
        }


        public bool RemoveItemFromCart(long productId)
        {

            var cart = GetCurrentCart();
            if (cart == null) return false;
            //delete the product from cart
            var cartProduct = _cartProducts.List().FirstOrDefault(c => c.CartId == cart.Id && c.ProductId == productId);
            if (cartProduct == null) return false;

            _cartProducts.Delete(cartProduct);

            return true;
        }


        public bool CompleteCartOrder()
        {  
            //get current user, then get his cart
            //transfer from the current cart to order entity
            throw new NotImplementedException();
        }
        public CartCrudVm GetCart()
        { //get a list of cart with all the items in the cart
            var existingCart = GetCurrentCart();

            if (existingCart == null) return null;
            var user = _permissionService.GetCurrentUser();
            if (user == null) return null;

            var model = new CartCrudVm
            {
                NameOnCard = user.FirstName + " " + user.LastName,
                Products = GetCartProductsByCartId(existingCart.Id),
                TotalCartPrice = GetTotalCartPrice(existingCart.Id)

            };

            return model;
        }

        private double GetTotalCartPrice(long existingCartId)
        {
         
            var cartProducts = GetCartProductsByCartId(existingCartId);
            return cartProducts.Sum(c => c.TotalProductPrice);
        }

        public List<CartProducts> GetCartProductsByCartId(long cartId)
        {
            var products = from prod in _productRepo.List()
                join cartProducts in _cartProducts.List() on prod.Id equals cartProducts.ProductId
                where cartProducts.CartId == cartId
                select new CartProducts
                {
                    Id = prod.Id,
                    ImageUrl = string.IsNullOrEmpty(prod.ImageUrl) ? "/images/default-image_100.png" : prod.ImageUrl,
                    Quantity = cartProducts.Quantity,
                    ProductName = prod.ProductName,
                    TotalProductPrice = prod.Price * cartProducts.Quantity
                };

            return products.ToList();
        }
    }

    public class CartCrudVm
    {
        public List<CartProducts> Products { get; set; }
        public string PaymentType { get; set; } //if YES, true, NO, false
        public double TotalCartPrice { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public int Cvv { get; set; }
    }

    public class CartProducts
    {
        public long Id { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public double TotalProductPrice { get; set; }
    }
}
