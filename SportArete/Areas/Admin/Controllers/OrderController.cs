using Microsoft.AspNetCore.Mvc;
using SportArete.Core.Contracts;
using SportArete.Core.Services;
using static Humanizer.In;

namespace SportArete.Areas.Admin.Controllers
{
    /// <summary>
    /// The Admin controller responsible for order management.
    /// </summary>
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        /// <summary>
        /// Shows all orders on the website.
        /// </summary>
        public async Task<IActionResult> All()
        {
            var model = await orderService.All();

            return View(model);
        }
    }
}
