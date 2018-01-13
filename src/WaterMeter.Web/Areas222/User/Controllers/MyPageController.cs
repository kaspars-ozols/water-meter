using System.Web.Mvc;
using WaterMeter.Core.Constants;
using WaterMeter.Web.Areas222.User.Models;

namespace WaterMeter.Web.Areas222.User.Controllers
{
    [Authorize(Roles = Role.User)]
    [RouteArea(nameof(User), AreaPrefix = "")]
    [RoutePrefix("")]
    public class MyPageController : Controller
    {
        [HttpGet]
        [Route("dashboard")]
        public ActionResult Dashboard()
        {
            var model = new DashboardViewModel();

            return View(model);
        }
    }
}