using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Services.OrdersServices;
using HerbsStore.Libraries.HS.Services.Security;
using Microsoft.AspNetCore.Mvc;

namespace HerbsStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IPermissionService _permissionService;

        public CartController(ICartService cartService,
            IPermissionService permissionService)
        {
            _cartService = cartService;
            _permissionService = permissionService;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            if (!_permissionService.Authorize())
                return Unauthorized();

            var model = _cartService.GetCart();
            return View(model);
        }

        [HttpPost]
        public IActionResult Checkout(CartCrudVm vm)
        {
            if (!_permissionService.Authorize())
                return Unauthorized();

            var success = _cartService.CompleteCartOrder(vm);
          //redirect to order confirmation
          //

          return RedirectToAction("OrderConfirmation", new {success = success});
        }


        public IActionResult AddProductQuantity(long id)
        {
            if (!_permissionService.Authorize())
                return Unauthorized();


            _cartService.AddQuantityToCart(id);
            return RedirectToAction("Checkout", "Cart");
        }

        public IActionResult SubtractProductQuantity(long id)
        {
            if (!_permissionService.Authorize())
                return Unauthorized();


            _cartService.SubtractQuantityToCart(id);
            return RedirectToAction("Checkout", "Cart");
        }
        
        public IActionResult DeleteProductFromCart(long id)
        {
            if (!_permissionService.Authorize())
                return Unauthorized();

            _cartService.RemoveItemFromCart(id);
            return RedirectToAction("Checkout", "Cart");
        }

        public IActionResult AddToCart(long id)
        {
            if (!_permissionService.Authorize())
                return Unauthorized();


            _cartService.AddProductToCart(id);
            return RedirectToAction("List", "Products");
        }

        public IActionResult OrderConfirmation(bool success)
        {
            return View(success);
        }
    }
}