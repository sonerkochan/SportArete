using Microsoft.AspNetCore.Mvc;

namespace SportArete.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
