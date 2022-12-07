using Microsoft.AspNetCore.Mvc;
using SportArete.Core.Contracts;

namespace SportArete.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductService productService;

        public CategoryController(
            IProductService _productService)
        {
            productService = _productService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await productService.GetCategoriesAsync();

            return View(model);
        }
    }
}
