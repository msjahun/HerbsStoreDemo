using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Services.HospitalServices;
using HerbsStore.Libraries.HS.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace HerbsStore.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IProductService _productService;
        private readonly IHospitalService _hospitalService;

        public AdministrationController(IProductService productService,
            IHospitalService hospitalService)
        {
            _productService = productService;
            _hospitalService = hospitalService;

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
            var model = _hospitalService.GetHospitals();
            return View(model);
        }


        [HttpGet]
        public IActionResult HospitalAdd()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult HospitalAdd(HospitalCrudVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);


            //its valid, send to productService return Id, passId to Edit
            var hospitalId = _hospitalService.HospitalAdd(vm);
            return RedirectToAction("HospitalEdit", "Administration", new { @id = hospitalId});
     
        }

        [HttpGet]
        public IActionResult HospitalEdit(long id)
        {

            var model = _hospitalService.GetHospitalById(id);
            if (model == null)
                return RedirectToAction("Hospitals", "Administration");
            return View(model);
           
        }


        [HttpPost]
        public IActionResult HospitalEdit(HospitalCrudVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);


            //its valid, send to productService return Id, passId to Edit
            var success = _hospitalService.HospitalUpdate(vm);
            return RedirectToAction("HospitalEdit", "Administration", new { @id = vm.Id });
        }

        public IActionResult DeleteHospital(long id)
        {
            //delete and redirect to Hospitals

            _hospitalService.DeleteHospital(id);

            return RedirectToAction("Hospitals");

        }

        public IActionResult Feedbacks()
        {
            return View();
        }

        public IActionResult DeleteFeedback(long id)
        {
            //delete and redirect to Feedbacks
            throw new NotImplementedException();
        }


    }
}