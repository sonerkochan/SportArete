using Microsoft.AspNetCore.Mvc;
using static SportArete.Areas.Admin.Constants.AdminConstants;

namespace SportArete.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {   
        public IActionResult Index()
        {
            return View();
        }
    }
}
