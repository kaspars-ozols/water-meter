using System.Web.Mvc;
using WaterMeter.Core.Constants;

namespace WaterMeter.Web.Features
{
    public class RootController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (HttpContext.User.IsInRole(Role.Administrator))
                {
                    //return RedirectToAction("List", "Property", new {area = "Administration"});
                }

                //return RedirectToAction("Dashboard", "MyPage", new { area = "User" });

            }

            return new HttpUnauthorizedResult();
        }
    }
}