﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportArete.Core.Contracts;
using SportArete.Core.Data;
using SportArete.Core.Models.Product;
using SportArete.Core.Services;
using SportArete.Infrastructure.Data.Common;
using SportArete.Infrastructure.Data.Models;
using System.Security.Claims;

namespace SportArete.Controllers
{
    [Authorize]
    public class CartController : Controller
    {

        private readonly ApplicationDbContext context;
        private readonly IRepository repo;
        private readonly ICartService cartService;
        private readonly UserManager<User> userManager;

        public CartController(
            ICartService _cartService,
            ApplicationDbContext _context,
            IRepository _repo,
            UserManager<User> _userManager)
        {
            cartService = _cartService;
            context = _context;
            repo = _repo;
            userManager = _userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!context.Carts.Any(c => c.UserId == userId))
            {
                await cartService.CreateCartForUser(userId);
            }

            Cart cart = await repo.All<Cart>()
                .FirstOrDefaultAsync(c => c.UserId == userId);

            var cartProducts = repo.AllReadonly<CartProduct>().Where(c => c.CartId == cart.Id);

            if(cartProducts.Any(cp=>cp.ProductId==productId))
            {
                return RedirectToAction(nameof(MyCart));
            }
            await cartService.AddToCartAsync(userId, productId);

            return RedirectToAction(nameof(MyCart));
        }

        [HttpGet]
        public async Task<IActionResult> MyCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!context.Carts.Any(c => c.UserId == userId))
            {
                await cartService.CreateCartForUser(userId);
            }

            var model = await cartService.GetAllAsync(userId);

            return View(model);
        }
    }
}
