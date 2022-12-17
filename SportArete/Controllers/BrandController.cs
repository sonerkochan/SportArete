using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportArete.Core.Contracts;
using SportArete.Core.Data;
using SportArete.Core.Models.Brand;
using SportArete.Core.Models.Product;

namespace SportArete.Controllers
{
    /// <summary>
    /// The controller is responsible for brand management.
    /// </summary>
    [Authorize]
    public class BrandController : Controller
    {
        private readonly IProductService productService;
        private readonly IBrandService brandService;

        public BrandController(
            IProductService _productService,
            IBrandService _brandService)
        {
            productService = _productService;
            brandService = _brandService;
        }

        /// <summary>
        /// Shows all available brands.
        /// </summary>
        /// <returns>Page with all brands.</returns>
        [AllowAnonymous]
        public async Task <IActionResult> Index()
        {
            var model = await productService.GetBrandsAsync();

            return View(model);
        }

    }
}
