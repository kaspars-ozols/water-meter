using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using WaterMeter.Web.Features.Shared.Login;
using WaterMeter.Web.Infrastructure.MVC;

namespace WaterMeter.Web.Features.Shared.Profile
{
    [RoutePrefix("")]
    public class ProfileController : Controller
    {
        private readonly ApplicationSignInManager _signInManager;

        public ProfileController(ApplicationSignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        [Route("profile")]
        public ActionResult ViewProfile()
        {
            return View(nameof(ViewProfile), null);
        }

        [HttpPost]
        [Route("profile/edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditProfile(LoginViewModel model)
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

            return View(nameof(EditProfile), model);
        }
    }
}