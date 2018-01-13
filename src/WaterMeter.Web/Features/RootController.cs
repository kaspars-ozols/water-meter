using System.Web.Mvc;
using WaterMeter.Core.Constants;
using WaterMeter.Web.Features.Administrator.Dashboard;
using WaterMeter.Web.Features.User.Overview;
using WaterMeter.Web.Infrastructure.MVC;

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
                    return this.RedirectToAction<DashboardController>(x=>x.Index());
                }

                return this.RedirectToAction<OverviewController>(x => x.Index());
            }

            return new HttpUnauthorizedResult();
        }
    }
}