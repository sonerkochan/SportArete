using Microsoft.AspNetCore.Mvc;

namespace SportArete.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
