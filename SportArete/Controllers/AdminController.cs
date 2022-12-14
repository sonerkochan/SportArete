using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportArete.Core.Contracts;
using SportArete.Core.Services;
using static Humanizer.In;
using System.Security.Claims;

namespace SportArete.Controllers
{
    //[Area(AdminAreaName)]
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly IProductService productService;

        public AdminController(IProductService _productService)
        {
            productService = _productService;
        }
        public IActionResult Menu()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Products()
        {
            var model = await productService.GetAllAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            await productService.RemoveProductAsync(id);

            return RedirectToAction(nameof(Products));
        }

    }
}
