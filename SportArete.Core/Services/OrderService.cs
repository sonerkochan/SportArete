using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportArete.Core.Contracts;
using SportArete.Core.Data;
using SportArete.Core.Models.Order;
using SportArete.Core.Models.User;
using SportArete.Infrastructure.Data.Common;
using SportArete.Infrastructure.Data.Models;
using System.ComponentModel;
using System.Security.Claims;

namespace SportArete.Core.Services
{
    /// <summary>
    /// This Service is responsible for dealing with action relating the orders.
    /// </summary>
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

        [Description("Creates an empty order which will be filled later..")]
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

        [Description("Returns all ids of the products that the user has in their cart")]
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

        [Description("Creates an order and clears the cart of the current user.")]
        public async Task AddOrderAsync(AddOrderViewModel model, string userId)
        {
            var productsIds = GetAllProductIds(userId);

            decimal totalPrice = 0;

            foreach (var productId in productsIds)
            {
                totalPrice += repo.All<Product>().Where(p => p.Id == productId).FirstOrDefault().Price;
            }


            var entity = new Order()
            {
                FullName = model.FullName,
                Phone = model.Phone,
                Address = model.Address,
                PostalCode = model.PostalCode,
                TotalPrice = totalPrice,
                OrderDate = DateTime.Today,
                UserId = userId,
                IsComplete = false
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

            await cartService.ClearCartAsync(userId, productsIds);

            await repo.SaveChangesAsync();
        }

        [Description("Returns all orders.")]
        public async Task<IEnumerable<OrderViewModel>> All()
        {
            List<OrderViewModel> result;

            result = await repo.AllReadonly<Order>()
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    Address = o.Address,
                    PostalCode = o.PostalCode,
                    TotalPrice = o.TotalPrice,
                    OrderDate = o.OrderDate,
                    UserId = o.UserId,
                    IsComplete = o.IsComplete,
                    FullName = o.FullName,
                    Phone = o.Phone
                })
                .ToListAsync();

            return result;
        }

        [Description("Returns all orders of a given user by his Id.")]
        public async Task<IEnumerable<OrderViewModel>> Mine(string userId)
        {
            List<OrderViewModel> result;

            result = await repo.AllReadonly<Order>()
                .Where(o => o.UserId == userId)
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    Address = o.Address,
                    PostalCode = o.PostalCode,
                    TotalPrice = o.TotalPrice,
                    OrderDate = o.OrderDate,
                    UserId = o.UserId,
                    IsComplete = o.IsComplete,
                    FullName = o.FullName,
                    Phone = o.Phone
                })
                .ToListAsync();

            return result;
        }


        public async Task<bool> Confirm(int orderId)
        {
            var order = await repo.All<Order>().FirstOrDefaultAsync(o => o.Id == orderId);

            order.IsComplete = true;

            await repo.SaveChangesAsync();

            return true;
        }
    }
}