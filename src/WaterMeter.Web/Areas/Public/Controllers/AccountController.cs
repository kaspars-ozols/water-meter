using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WaterMeter.Core.Constants;
using WaterMeter.Web.Areas.User.Models;

namespace WaterMeter.Web.Areas.Public.Controllers
{
    [RouteArea(nameof(Public), AreaPrefix = "")]
    [RoutePrefix("")]
    public class AccountController : Controller
    {
        private readonly ApplicationSignInManager _signInManager;
        private readonly IAuthenticationManager _authenticationManager;
        private ApplicationUserManager _userManager;

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, IAuthenticationManager authenticationManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationManager = authenticationManager;
        }

        [HttpGet]
        [Route("login")]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        [Route("login")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result == SignInStatus.Success)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        var roles = (User.Identity as ClaimsIdentity)?.Claims
                            .Where(x => x.Type == ClaimTypes.Role)
                            .Select(x => x.Value)
                            .ToList()?? new List<string>();

                        if (roles.Contains(Role.Administrator))
                        {
                            return RedirectToAction("Dashboard", "Dashboard", new {Area = "Administration"});
                        }


                        return new RedirectResult(model.ReturnUrl);
                    }

                    return new RedirectResult(model.ReturnUrl);
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }

            return View(model);
        }

        [HttpPost]
        [Route("logout")]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Index", "Landing", new { Area = "Public" });
        }
    }
}