using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportArete.Core.Contracts;
using SportArete.Core.Models.Product;
using SportArete.Core.Services;

namespace SportArete.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(int productId)
        {
            return RedirectToAction("Detail", "Product", productId);
        }
    }
}
