using Microsoft.EntityFrameworkCore;
using SportArete.Core.Contracts;
using SportArete.Core.Data;
using SportArete.Core.Models.Product;
using SportArete.Infrastructure.Data.Common;
using SportArete.Infrastructure.Data.Models;
using System.Net;

namespace SportArete.Core.Services
{
    public class OrderService : IOrderService
    {

        private readonly IRepository repo;
        private readonly ApplicationDbContext context;
        public OrderService(
            ApplicationDbContext _context,
            IRepository _repo)
        {
            repo = _repo;
            context = _context;
        }

        public async Task CreateOrderForUser(string userId)
        {
            var order = new Order()
            {
                UserId = userId,
                FullName = "To be added",
                Address = "To be added",
                Phone = "To be added",
                PostalCode = "TBA",
                TotalPrice = 0,
                OrderDate = DateTime.Now
            };

            await repo.AddAsync(order);
            await repo.SaveChangesAsync();
        }

        public List<int> GetAllProductIds(string userId)
        {
            List<int> productIds = new List<int>();
            
            Cart cart = repo.All<Cart>()
                .FirstOrDefault(c => c.UserId == userId);

            var cartProducts = repo.AllReadonly<CartProduct>().Where(c => c.CartId == cart.Id);

            foreach (var product in cartProducts)
            {
                productIds.Add(product.ProductId);
            }
            

            return productIds;
        }
    }
}
