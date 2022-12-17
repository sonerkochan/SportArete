using Microsoft.AspNetCore.Mvc;
using SportArete.Core.Contracts;
using SportArete.Core.Services;

namespace SportArete.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }
        public async Task<IActionResult> All()
        {
            var model = await orderService.All();

            return View(model);
        }
    }
}
