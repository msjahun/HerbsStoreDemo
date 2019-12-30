using HerbsStore.Libraries.HS.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace HerbsStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
  
        public IActionResult List()
        {
            var products = _productService.GetProducts();
            return View(products);
        }
    }
}