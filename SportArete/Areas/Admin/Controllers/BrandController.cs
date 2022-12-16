using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportArete.Core.Models.Brand;
using SportArete.Core.Services;

namespace SportArete.Areas.Admin.Controllers
{
    public class BrandController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddBrandViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBrandViewModel addBrandViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addBrandViewModel);
            }

            try
            {
                await brandService.AddBrandAsync(addBrandViewModel);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(addBrandViewModel);
            }
        }
    }
}
