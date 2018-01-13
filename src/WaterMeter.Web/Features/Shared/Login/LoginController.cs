using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using WaterMeter.Web.Infrastructure.MVC;

namespace WaterMeter.Web.Features.Shared.Login
{
    [RoutePrefix("")]
    public class LoginController : Controller
    {
        private readonly ApplicationSignInManager _signInManager;

        public LoginController(ApplicationSignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        [Route("login")]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(nameof(Login), model);
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
                    return !string.IsNullOrEmpty(model.ReturnUrl) ? 
                        new RedirectResult(model.ReturnUrl) : 
                        this.RedirectToAction<RootController>(x => x.Index());
                }
                ModelState.AddModelError("", "Failed to log in.");
            }

            return View(nameof(Login), model);
        }
    }
}