using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportArete.Infrastructure.Data.Models;

namespace SportArete.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Shipment(Cart cart)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Shipment(int i)
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
