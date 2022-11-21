using SportArete.Core.Contracts;
using SportArete.Infrastructure.Data.Common;
using SportArete.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using SportArete.Core.Models.Product;
using Microsoft.EntityFrameworkCore;
using SportArete.Core.Data;

namespace SportArete.Core.Services
{
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

        public async Task CreateCartForUser(string userId)
        {
            var cart = new Cart()
            {
                UserId = userId
            };

            await repo.AddAsync(cart);
            await repo.SaveChangesAsync();
        }

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
    }
}