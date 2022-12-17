using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportArete.Core.Contracts;
using SportArete.Core.Data;
using SportArete.Core.Models.Order;
using SportArete.Core.Services;
using SportArete.Infrastructure.Data.Common;
using SportArete.Infrastructure.Data.Models;
using System.Security.Claims;

namespace SportArete.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository repo;
        private readonly IOrderService orderService;
        private readonly ICartService cartService;
        private readonly UserManager<User> userManager;

        public OrderController(
            IOrderService _orderService,
            ApplicationDbContext _context,
            IRepository _repo,
            UserManager<User> _userManager,
            ICartService _cartService)
        {
            orderService = _orderService;
            context = _context;
            repo = _repo;
            userManager = _userManager;
            cartService = _cartService;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!cartService.AnyProducts(userId))
            {
                return RedirectToAction("Index", "Home");
            }


            var productsIds = orderService.GetAllProductIds(userId);

            var model = new AddOrderViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddOrderViewModel addOrderViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addOrderViewModel);
            }

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await orderService.AddOrderAsync(addOrderViewModel, userId);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(addOrderViewModel);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Payment(int shipmentId)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Payment()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await orderService.Mine(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Confirm(int orderId)
        {
            bool result = await orderService.Confirm(orderId);

            return RedirectToAction(nameof(Mine));
        }
    }
}
