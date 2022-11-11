using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SportArete.Core.Contracts;
using SportArete.Core.Models.Product;
using SportArete.Core.Services;

namespace SportArete.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddProductViewModel()
            {
                Categories = await productService.GetCategoriesAsync(),
                Brands = await productService.GetBrandsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel addProductViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addProductViewModel);
            }

            try
            {
                await productService.AddProductAsync(addProductViewModel);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(addProductViewModel);
            }
        }
    }
}
