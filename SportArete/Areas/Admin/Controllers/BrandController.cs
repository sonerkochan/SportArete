using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportArete.Core.Contracts;
using SportArete.Core.Models.Brand;
using SportArete.Core.Services;

namespace SportArete.Areas.Admin.Controllers
{
    public class BrandController : BaseController
    {
        private readonly IBrandService brandService;

        public BrandController(
            IBrandService _brandService)
        {
            brandService = _brandService;
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
