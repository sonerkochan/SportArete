using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportArete.Core.Contracts;
using SportArete.Core.Models.Brand;
using SportArete.Core.Services;

namespace SportArete.Areas.Admin.Controllers
{
    /// <summary>
    /// The Admin controller responsible for brand management.
    /// </summary>
    public class BrandController : BaseController
    {
        private readonly IBrandService brandService;

        public BrandController(
            IBrandService _brandService)
        {
            brandService = _brandService;
        }

        /// <summary>
        /// Method to add a new brand to the website.
        /// </summary>
        /// <returns>A form to fill with data of the new brand.</returns>
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddBrandViewModel();

            return View(model);
        }

        /// <summary>
        /// Validates the data of the newly added brand before adding it to the database.
        /// </summary>
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
