using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportArete.Core.Contracts;
using SportArete.Core.Data;
using SportArete.Core.Models.Product;
using SportArete.Core.Models.Review;
using SportArete.Infrastructure.Data.Models;
using System.Security.Claims;

namespace SportArete.Controllers
{
    /// <summary>
    /// The controller is responsible for product management.
    /// </summary>
    [Authorize]
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext context;
        private readonly IProductService productService;
        private readonly IReviewService reviewService;
        private readonly IUserService userService;

        public ProductController(
            IProductService _productService,
            ApplicationDbContext _context,
            IReviewService _reviewService,
            IUserService _userService)
        {
            productService = _productService;
            context = _context;
            reviewService = _reviewService;
            userService = _userService;
        }

        /// <summary>
        /// Method for getting all available products
        /// </summary>
        /// <returns>All available products</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = await productService.GetAllAsync();

            return View(model);
        }

        /// <summary>
        /// Method for adding a review.
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <returns>View to fill a review form.</returns>
        [HttpGet]
        public async Task<IActionResult> AddReview(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = new AddReviewViewModel()
            {
                ProductId = id,
                UserId = userId
            };

            return View(model);
        }

        /// <summary>
        /// Method for adding a review.
        /// </summary>
        /// <param name="addReviewViewModel">A DTO filled with data.</param>
        /// <returns>Adds a review to the product and returns the user to the index page.</returns>
        [HttpPost]
        public async Task<IActionResult> AddReview(AddReviewViewModel addReviewViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addReviewViewModel);
            }

            try
            {
                await reviewService.AddReviewAsync(addReviewViewModel);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(addReviewViewModel);
            }
        }

        /// <summary>
        /// Method for showing all the information of a product.
        /// </summary>
        /// <param name="id">Product's id.</param>
        /// <returns>Product's page.</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
            Product viewedProduct = await context.Products
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            viewedProduct.ViewsCount++;

            await context.SaveChangesAsync();

            var reviews = reviewService.GetProductReviews(id)
                .Select(x => new ReviewViewModel()
                {
                    Id = x.Id,
                    Comment = x.Comment,
                    Rating = x.Rating,
                    ProductId = x.ProductId,
                    UserId = x.UserId,
                    UserName = userService.GetUserNameById(x.UserId)
                }).ToList();

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
                    Brand = p.Brand.Name,
                    Reviews = reviews
                }).FirstOrDefaultAsync();


            if (product != null)
            {
                return View(product);
            }

            return RedirectToAction("All", "Products");
        }

        /// <summary>
        /// Shows all products of a certain brand.
        /// </summary>
        /// <param name="brandId">Brand's Id.</param>
        /// <returns>Page with products of a certain brand.</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Brand(int brandId)
        {
            var model = await productService.GetAllByBrandAsync(brandId);

            return View(model);
        }

        /// <summary>
        /// Shows all products of a certain category.
        /// </summary>
        /// <param name="brandId">Category's Id.</param>
        /// <returns>Page with products of a certain category.</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Category(int categoryId)
        {
            var model = await productService.GetAllByCategoryAsync(categoryId);

            return View(model);
        }
    }
}
