using Microsoft.AspNetCore.Mvc;

namespace SportArete.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Menu()
        {
            return View();
        }
    }
}
