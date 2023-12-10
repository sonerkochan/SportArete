using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportArete.Core.Contracts;
using SportArete.Core.Models.Product;

namespace SportArete.Areas.Admin.Controllers
{
    /// <summary>
    /// The Admin controller responsible for product management.
    /// </summary>
    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        /// <summary>
        /// Shows all available products on the website.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> AllAvailable()
        {
            var model = await productService.GetAllAsync();

            return View(model);
        }

        /// <summary>
        /// Method to remove a given products from the website.
        /// </summary>
        /// <param name="id">Product's Id.</param>
        [HttpPost]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            await productService.RemoveProductAsync(id);

            return RedirectToAction(nameof(AllAvailable));
        }

        /// <summary>
        /// Method to add a new product to the website.
        /// </summary>
        /// <returns>A form to fill with data of the new product.</returns>
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

        /// <summary>
        /// Validates the data of the newly added product before adding it to the database.
        /// </summary>
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
