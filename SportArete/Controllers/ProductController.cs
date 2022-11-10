using Microsoft.AspNetCore.Mvc;

namespace SportArete.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
