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
            if (cartService.AnyProducts(this.User.Identity.Name))
            {
                return RedirectToAction("Index", "Home");
            }


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int[] productIds)
        {
            return View();
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
    }
}
