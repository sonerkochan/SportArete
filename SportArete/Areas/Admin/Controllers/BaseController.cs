using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static SportArete.Areas.Admin.Constants.AdminConstants;

namespace SportArete.Areas.Admin.Controllers
{
    /// <summary>
    /// Base controller class that all other controllers in Admin area inherit in order to lock authorization.
    /// </summary>
    [Area(AdminAreaName)]
    [Route("/Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRoleName)]
    public class BaseController : Controller
    {

    }
}
