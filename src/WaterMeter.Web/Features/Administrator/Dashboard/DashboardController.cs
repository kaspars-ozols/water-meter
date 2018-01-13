using System.Web.Mvc;
using WaterMeter.Core.Constants;

namespace WaterMeter.Web.Features.Administrator.Dashboard
{
    [Authorize(Roles = Role.Administrator)]
    [RoutePrefix("")]
    public class DashboardController : Controller
    {
        [HttpGet]
        [Route("dashboard")]
        public ActionResult Index()
        {
            return View();
        }
    }
}