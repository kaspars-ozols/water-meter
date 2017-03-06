using System.Web.Mvc;
using WaterMeter.Core.Constants;

namespace WaterMeter.Web.Areas.Public.Controllers
{
    [RouteArea(nameof(Public), AreaPrefix = "")]
    [RoutePrefix("")]
    public class LandingController : Controller
    {
        [HttpGet]
        [Route("")]
        [Authorize]
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (HttpContext.User.IsInRole(Role.User))
                {
                    return RedirectToAction("Dashboard", "MyPage", new { area = "User" });
                }

                return RedirectToAction("List", "Property", new { area = "Administration" });
            }

            return new HttpUnauthorizedResult();
        }
    }
}