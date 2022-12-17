using Microsoft.AspNetCore.Mvc;
using SportArete.Core.Contracts;

namespace SportArete.Controllers
{
    /// <summary>
    /// The controller is responsible for category management.
    /// </summary>
    public class CategoryController : Controller
    {
        private readonly IProductService productService;

        public CategoryController(
            IProductService _productService)
        {
            productService = _productService;
        }

        /// <summary>
        /// Shows all available categories.
        /// </summary>
        /// <returns>Page with all categories.</returns>
        public async Task<IActionResult> Index()
        {
            var model = await productService.GetCategoriesAsync();

            return View(model);
        }
    }
}
