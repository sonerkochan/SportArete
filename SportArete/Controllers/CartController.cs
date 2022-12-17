using Microsoft.AspNetCore.Authorization;
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
    /// <summary>
    /// The controller is responsible for cart management.
    /// </summary>
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

        /// <summary>
        /// Method for adding a product to the cart.
        /// </summary>
        /// <param name="productId">Product's id.</param>
        /// <returns>Adds a product to the user's cart.</returns>
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

            if (cartProducts.Any(cp => cp.ProductId == productId))
            {
                return RedirectToAction(nameof(MyCart));
            }
            await cartService.AddToCartAsync(userId, productId);

            return RedirectToAction(nameof(MyCart));
        }

        /// <summary>
        /// Opens the user's cart.
        /// </summary>
        /// <returns>Page of the user's cart.</returns>
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

        /// <summary>
        /// Removes a given product from the cart.
        /// </summary>
        /// <param name="productId">Product's id</param>
        /// <returns>Removes a selected product from the cart.</returns>
        [HttpPost]
        public async Task<IActionResult> Remove(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await cartService.RemoveFromCartAsync(userId, productId);

            return RedirectToAction(nameof(MyCart));
        }
    }
}