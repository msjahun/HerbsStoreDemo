using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace HerbsStore.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IProductService _productService;

        public AdministrationController(IProductService productService)
        {
            _productService = productService;

        }
        public IActionResult Products()
        {
            var model = _productService.GetProducts();
            return View(model);
        }

        [HttpGet]
        public IActionResult ProductAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProductAdd(ProductCrudVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);


            //its valid, send to productService return Id, passId to Edit
            var productId = _productService.ProductAdd(vm);
            return RedirectToAction("ProductEdit","Administration", new {@id = productId});
        }


        public IActionResult ProductEdit(long id)
        {
            //get product using id
            //if product == null, redirect to Products
            //if everything is okay, return view with model

            var model = _productService.GetProductById(id);
            if (model == null)
                return RedirectToAction("Products", "Administration");
            return View(model);
        }

        [HttpPost]
        public IActionResult ProductEdit(ProductCrudVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);


            //its valid, send to productService return Id, passId to Edit
            var success = _productService.ProductUpdate(vm);
            return RedirectToAction("ProductEdit", "Administration", new { @id = vm.Id });
        }

        public IActionResult DeleteProduct(long id)
        {
            //delete product, then redirect to products

            _productService.DeleteProduct(id);

            return RedirectToAction("Products");
        }
        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult OrderEdit()
        {
            return View();
        }

        public IActionResult OrderConfirm()
        {
            return View();
        }



        public IActionResult Hospitals()
        {
            return View();
        }

     
    }
}