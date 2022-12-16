﻿using Microsoft.AspNetCore.Authorization;
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


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = await productService.GetAllAsync();

            return View(model);
        }

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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Brand(int brandId)
        {
            var model = await productService.GetAllByBrandAsync(brandId);

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Category(int categoryId)
        {
            var model = await productService.GetAllByCategoryAsync(categoryId);

            return View(model);
        }
    }
}
