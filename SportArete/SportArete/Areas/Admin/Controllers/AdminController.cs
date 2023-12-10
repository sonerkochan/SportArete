using Microsoft.AspNetCore.Mvc;
using static SportArete.Areas.Admin.Constants.AdminConstants;

namespace SportArete.Areas.Admin.Controllers
{
    /// <summary>
    /// The Admin controller responsible for showing the menu..
    /// </summary>
    public class AdminController : BaseController
    {   
        /// <summary>
        /// Shows the admin menu.
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
    }
}
