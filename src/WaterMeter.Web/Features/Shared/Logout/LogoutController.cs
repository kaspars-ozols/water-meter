using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using WaterMeter.Web.Infrastructure.MVC;

namespace WaterMeter.Web.Features.Shared.Logout
{
    [RoutePrefix("")]
    public class LogoutController : Controller
    {
        private readonly IAuthenticationManager _authenticationManager;

        public LogoutController(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        [HttpPost]
        [Route("logout")]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return this.RedirectToAction<RootController>(x => x.Index());
        }
    }
}