using Microsoft.AspNetCore.Mvc;
using SportArete.Core.Contracts;
using SportArete.Core.Data;
using SportArete.Core.Models.Product;

namespace SportArete.Controllers
{
    public class BrandController : Controller
    {
        private readonly IProductService productService;

        public BrandController(
            IProductService _productService)
        {
            productService = _productService;
        }
        public async Task <IActionResult> Index()
        {
            var model = await productService.GetBrandsAsync();

            return View(model);
        }
    }
}
