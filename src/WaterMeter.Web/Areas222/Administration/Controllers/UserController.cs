using System.Threading.Tasks;
using System.Web.Mvc;
using WaterMeter.Core.Entities;
using WaterMeter.Web.Areas222.Administration.Models.User;

namespace WaterMeter.Web.Areas222.Administration.Controllers
{
    //[Authorize(Roles = Role.Administrator)]
    [RouteArea(nameof(Administration), AreaPrefix = "")]
    [RoutePrefix("user")]
    public class UserController : Controller
    {
        private readonly ApplicationUserManager _applicationUserManager;

        public UserController(ApplicationUserManager applicationUserManager)
        {
            _applicationUserManager = applicationUserManager;
        }
        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(CreateModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords must match");
            }

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                var result = await _applicationUserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("List", "Users");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }

            return View(model);
        }


    }
}