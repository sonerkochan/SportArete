using Microsoft.AspNetCore.Mvc;
using SportArete.Core.Contracts;
using SportArete.Core.Models;
using SportArete.Core.Services;
using System.Diagnostics;
using static SportArete.Areas.Admin.Constants.AdminConstants;

namespace SportArete.Controllers
{
    /// <summary>
    /// The controller is responsible for user management.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProductService productService;

        public HomeController(
            ILogger<HomeController> logger,
            IProductService _productService)
        {
            _logger = logger;
            productService = _productService;
        }

        /// <summary>
        /// Index page of the site. Top products are displayed here.
        /// </summary>
        /// <returns>Index page of the website.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }
            var model = await productService.GetTopAsync();

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}