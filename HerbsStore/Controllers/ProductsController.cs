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
  
        public IActionResult List(ProductCrudVm vm)
        {
            var model = new ProductCrudVm {List = _productService.GetProducts(vm)};
            return View(model);
        }

        public IActionResult Detail(long id)
        {
            var products = _productService.GetProductById(id);
            if (products == null) RedirectToAction("List");
            return View(products);
        }
    }
}