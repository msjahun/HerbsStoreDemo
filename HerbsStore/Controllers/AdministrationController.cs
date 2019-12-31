using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Core.Domain.Diseases;
using HerbsStore.Libraries.HS.Services.DiseaseServices;
using HerbsStore.Libraries.HS.Services.FeedbackServices;
using HerbsStore.Libraries.HS.Services.HospitalServices;
using HerbsStore.Libraries.HS.Services.OrdersServices;
using HerbsStore.Libraries.HS.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace HerbsStore.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IProductService _productService;
        private readonly IHospitalService _hospitalService;
        private readonly IFeedbackService _feedbackService;
        private readonly IOrderService _orderService;
        private readonly IDiseaseService _diseaseService;

        public AdministrationController(IProductService productService,
            IHospitalService hospitalService,
            IFeedbackService feedbackService,
            IOrderService orderService,
            IDiseaseService diseaseService)
        {
            _productService = productService;
            _hospitalService = hospitalService;
            _feedbackService = feedbackService;
            _orderService = orderService;
            _diseaseService = diseaseService;

        }
        public IActionResult Products(ProductCrudVm vm)
        {
            var model = _productService.GetProducts(vm);
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
            var model = _orderService.GetOrders();
            return View(model);
        }

    

        public IActionResult OrderConfirmToggle(long id)
        {
            _orderService.OrderConfirmationToggle(id);

            return RedirectToAction("Orders");
        }

        public IActionResult OrderDelete(long id)
        {
            _orderService.DeleteOrder(id);

            return RedirectToAction("Orders");
        }



        public IActionResult Diseases()
        {
            var model = _diseaseService.GetDiseases();
            return View(model);
        }


        [HttpGet]
        public IActionResult DiseaseAdd()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult DiseaseAdd(DiseaseCrudVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);


            //its valid, send to disease Service return Id, passId to Edit
            var diseaseId = _diseaseService.DiseaseAdd(vm); 
            return RedirectToAction("DiseaseEdit", "Administration", new { @id = diseaseId});
     
        }

        [HttpGet]
        public IActionResult DiseaseEdit(long id)
        {

            var model =  _diseaseService.GetDiseaseById(id);
            if (model == null)
                return RedirectToAction("Diseases", "Administration");
            return View(model);
           
        }


        [HttpPost]
        public IActionResult DiseaseEdit(DiseaseCrudVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);


            //its valid, send to productService return Id, passId to Edit
            
            var success = _diseaseService.DiseaseUpdate(vm);
            return RedirectToAction("DiseaseEdit", "Administration", new { @id = vm.Id });
        }

        public IActionResult DeleteDisease(long id)
        {
            //delete and redirect to Hospitals

            _diseaseService.DeleteDisease(id);

            return RedirectToAction("Diseases");

        }



        public IActionResult Hospitals()
        {
            var model = _hospitalService.GetHospitals(new HospitalCrudVm());
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
            return RedirectToAction("HospitalEdit", "Administration", new { @id = hospitalId });

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
            var model = _feedbackService.GetFeedBack();
            return View(model);
        }

        public IActionResult DeleteFeedback(long id)
        {
            //delete and redirect to Feedbacks

            _feedbackService.DeleteFeedBack(id);

            return RedirectToAction("Feedbacks");
        }


    }
}