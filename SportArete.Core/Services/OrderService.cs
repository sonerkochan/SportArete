using Microsoft.AspNetCore.Identity;
using SportArete.Core.Contracts;
using SportArete.Core.Data;
using SportArete.Core.Models.Order;
using SportArete.Infrastructure.Data.Common;
using SportArete.Infrastructure.Data.Models;
using System.Security.Claims;

namespace SportArete.Core.Services
{
    public class OrderService : IOrderService
    {

        private readonly IRepository repo;
        private readonly ICartService cartService;
        private readonly ApplicationDbContext context;
        private readonly UserManager<User> userManager;
        public OrderService(
            ApplicationDbContext _context,
            IRepository _repo,
            UserManager<User> _userManager,
            ICartService _cartService)
        {
            repo = _repo;
            context = _context;
            userManager = _userManager;
            cartService = _cartService;
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

        public async Task AddOrderAsync(AddOrderViewModel model, string userId)
        {
            var productsIds = GetAllProductIds(userId);

            decimal totalPrice = 0;

            foreach (var productId in productsIds)
            {
                totalPrice += repo.All<Product>().Where(p => p.Id == productId).FirstOrDefault().Price;
            }

            //decimal totalPrice = repo.All<Product>().Sum(p => p.Price);

            var entity = new Order()
            {
                FullName = model.FullName,
                Phone = model.Phone,
                Address = model.Address,
                PostalCode = model.PostalCode,
                TotalPrice = totalPrice,
                OrderDate = DateTime.Today,
                UserId = userId,
                IsComplete = true
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();

            int orderId = repo.All<Order>().OrderByDescending(x => x.Id).FirstOrDefault().Id;

            foreach (var productId in productsIds)
            {
                OrderProduct orderProduct = new OrderProduct()
                {
                    ProductId = productId,
                    OrderId = orderId
                };
                await repo.AddAsync(orderProduct);//Check if OrderProduct is created
            }

            cartService.ClearCartAsync(userId, productsIds);

            await repo.SaveChangesAsync();
        }
    }
}
