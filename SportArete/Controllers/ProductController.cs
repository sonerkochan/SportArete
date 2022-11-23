using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportArete.Core.Contracts;
using SportArete.Core.Data;
using SportArete.Core.Models.Product;
using SportArete.Infrastructure.Data.Models;

namespace SportArete.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext context;
        private readonly IProductService productService;

        public ProductController(
            IProductService _productService,
            ApplicationDbContext _context)
        {
            productService = _productService;
            context = _context;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = await productService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
            Product viewedProduct = await context.Products
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            viewedProduct.ViewsCount++;

            await context.SaveChangesAsync();


            var product = await context.Products
                .Where(p => p.Id == id)
                .Select(p => new DetailedProductViewModel()
                {
                    Id = p.Id,
                    Model = p.Model,
                    Description = p.Description,
                    Size = p.Size,
                    Price = p.Price,
                    ImageData = p.ImageData,
                    Category = p.Category.Name,
                    Brand = p.Brand.Name


                }).FirstOrDefaultAsync();


            if (product != null)
            {
                return View(product);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
