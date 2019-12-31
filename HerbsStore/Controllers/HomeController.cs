using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using HerbsStore.Models;

namespace HerbsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public IActionResult Index()
        {
            var products = new ProductCrudVm
            {
                List = _productService.GetProducts(new ProductCrudVm()).Take(3).ToList()

            };
        
            return View(products); 
        }



        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

    
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
