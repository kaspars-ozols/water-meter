using System.Web.Mvc;
using WaterMeter.Web.Areas.User.Models;

namespace WaterMeter.Web.Areas.User.Controllers
{
    //[Authorize(Roles = Role.User)]
    [RouteArea(nameof(User), AreaPrefix = "")]
    [RoutePrefix("")]
    public class DashboardController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var model = new DashboardViewModel();

            return View(model);
        }
    }
}