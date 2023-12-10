using Microsoft.AspNetCore.Mvc;
using SportArete.Core.Contracts;

namespace SportArete.Areas.Admin.Controllers
{
    /// <summary>
    /// The Admin controller responsible for user management.
    /// </summary>
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        /// <summary>
        /// Shows all user on the website.
        /// </summary>
        public async Task<IActionResult> All()
        {
            var model = await userService.All();

            return View(model);
        }

        /// <summary>
        /// Method to disable a user's account.
        /// </summary>
        /// <param name="userId">User's id.</param>
        [HttpPost]
        public async Task<IActionResult> Forget(string userId)
        {
            bool result = await userService.Forget(userId);

            return RedirectToAction(nameof(All));
        }
    }
}
