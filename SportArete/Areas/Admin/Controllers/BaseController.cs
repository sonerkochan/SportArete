using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static SportArete.Areas.Admin.Constants.AdminConstants;

namespace SportArete.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Route("/Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRoleName)]

    public class BaseController : Controller
    {

    }
}
