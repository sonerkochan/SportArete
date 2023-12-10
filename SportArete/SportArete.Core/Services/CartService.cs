using SportArete.Core.Contracts;
using SportArete.Infrastructure.Data.Common;
using SportArete.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using SportArete.Core.Models.Product;
using Microsoft.EntityFrameworkCore;
using SportArete.Core.Data;
using System.ComponentModel;

namespace SportArete.Core.Services
{
    /// <summary>
    /// This Service is responsible for dealing with action relating the carts.
    /// </summary>
    public class CartService : ICartService
    {
        private readonly IRepository repo;
        private readonly ApplicationDbContext context;
        public CartService(
            ApplicationDbContext _context,
            IRepository _repo)
        {
            repo = _repo;
            context = _context;
        }

        [Description("Adds a selected product to the cart of the user.")]
        public async Task AddToCartAsync(string userId, int productId)
        {
            Cart cart = await repo.All<Cart>()
                .FirstOrDefaultAsync(c => c.UserId == userId);

            int cartId = cart.Id;

            var entity = new CartProduct()
            {
                CartId = cartId,
                ProductId = productId
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }

        [Description("Upon registration a user does not have a cart, after trying to see their cart or add one, a cart gets created.")]
        public async Task CreateCartForUser(string userId)
        {
            var cart = new Cart()
            {
                UserId = userId
            };

            await repo.AddAsync(cart);
            await repo.SaveChangesAsync();
        }

        [Description("Returns all products in the user's cart.")]
        public async Task<IEnumerable<ProductViewModel>> GetAllAsync(string userId)
        {
            Cart cart = await repo.All<Cart>()
                .FirstOrDefaultAsync(c => c.UserId == userId);

            int cartId = cart.Id;

            return await repo.AllReadonly<CartProduct>()
                .Where(cp => cp.CartId == cartId)
                .Select(cp => new ProductViewModel()
                {
                    Id = cp.Product.Id,
                    Model = cp.Product.Model,
                    Price = cp.Product.Price,
                    ImageData = cp.Product.ImageData,
                    Category = cp.Product.Category.Name,
                    Brand = cp.Product.Brand.Name
                })
                .OrderBy(p => p.Category)
                .ToListAsync();
        }

        [Description("Removes a selected product from the cart.")]
        public async Task RemoveFromCartAsync(string userId, int productId)
        {
            Cart cart = await repo.All<Cart>()
                .FirstOrDefaultAsync(c => c.UserId == userId);

            int cartId = cart.Id;

            CartProduct removed = await repo.All<CartProduct>()
                .Where(cp => cp.CartId == cartId)
                .FirstOrDefaultAsync(cp => cp.ProductId == productId);

            context.Remove<CartProduct>(removed);
            await context.SaveChangesAsync();
        }

        [Description("Clears all products from a given user's cart")]
        public async Task ClearCartAsync(string userId, List<int> productIds)
        {
            Cart cart = await repo.All<Cart>()
                .FirstOrDefaultAsync(c => c.UserId == userId);

            int cartId = cart.Id;

            foreach (var id in productIds)
            {
                CartProduct removed = await repo.All<CartProduct>()
                .Where(cp => cp.CartId == cartId)
                .FirstOrDefaultAsync(cp => cp.ProductId == id);

                context.Remove<CartProduct>(removed);
            }

            await context.SaveChangesAsync();
        }

        [Description("Checks if a given user's cart contains any products. " +
            "Retruns TRUE if contains, FALSE if does not.")]
        public bool AnyProducts(string userId)
        {
            return repo.All<CartProduct>().Any(x => x.Cart.UserId == userId);
        }
    }
}