using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WaterMeter.Core.Constants;
using WaterMeter.Core.Entities;
using WaterMeter.Web.Infrastructure.MVC;

namespace WaterMeter.Web.Features.Administrator.Users
{
    [Authorize(Roles = Role.Administrator)]
    [RoutePrefix("users")]
    public class UserController : Controller
    {
        private readonly ApplicationUserManager _userManager;

        public UserController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("list")]
        public ActionResult ListUsers()
        {
            var model = new ListModel
            {
                Users = _userManager.Users
                    .ToList()
                    .Select(x => new ListItemModel
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        MobilePhone = x.MobilePhone
                    })
                    .ToList()
            };
            return View(nameof(ListUsers), model);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult CreateUser()
        {
            var model = new CreateModel();

            return View(nameof(CreateUser), model);
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    MobilePhone = model.MobilePhone
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return this.RedirectToAction(x => x.ListUsers());
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }

            return View(nameof(CreateUser), model);
        }


        [HttpGet]
        [Route("edit/{id}")]
        public async Task<ActionResult> EditUser(string id)
        {
            var user = GetUserOrThrow(id);
            var roles = await _userManager.GetRolesAsync(id);

            var model = new EditModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobilePhone = user.MobilePhone,
                Email = user.Email,
                IsAdministrator = roles.Contains(Role.Administrator),
                IsAccountant = roles.Contains(Role.Accountant)
            };

            return View(nameof(EditUser), model);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(string id, EditModel model)
        {
            if (ModelState.IsValid)
            {
                var user = GetUserOrThrow(id);
                var roles = await _userManager.GetRolesAsync(user.Id);

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.MobilePhone = model.MobilePhone;
                user.UserName = model.Email;
                user.Email = model.Email;

                var results = new List<IdentityResult>
                {
                    await _userManager.UpdateAsync(user)
                };

                if (model.IsAdministrator)
                {
                    if (!roles.Contains(Role.Administrator))
                    {
                        results.Add(await _userManager.AddToRoleAsync(user.Id, Role.Administrator));
                    }
                }
                else
                {
                    if (roles.Contains(Role.Administrator))
                    {
                        results.Add(await _userManager.RemoveFromRoleAsync(user.Id, Role.Administrator));
                    }
                }

                if (model.IsAccountant)
                {
                    if (!roles.Contains(Role.Accountant))
                    {
                        results.Add(await _userManager.AddToRoleAsync(user.Id, Role.Accountant));
                    }
                }
                else
                {
                    if (roles.Contains(Role.Accountant))
                    {
                        results.Add(await _userManager.RemoveFromRoleAsync(user.Id, Role.Accountant));
                    }
                }

                if (!string.IsNullOrEmpty(model.Password))
                {
                    results.AddRange(new[]
                    {
                        await _userManager.RemovePasswordAsync(user.Id),
                        await _userManager.AddPasswordAsync(user.Id, model.Password)
                    });
                }

                if (results.All(x => x.Succeeded))
                {
                    return this.RedirectToAction(x => x.ListUsers());
                }

                foreach (var error in results.SelectMany(x => x.Errors))
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }

            return View(nameof(EditUser), model);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult DeleteUser(string id)
        {
            var user = GetUserOrThrow(id);
            var model = new DeleteModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return View(nameof(DeleteUser), model);
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteUser(string id, DeleteModel model)
        {
            if (ModelState.IsValid)
            {
                var user = GetUserOrThrow(id);
                await _userManager.DeleteAsync(user);

                return this.RedirectToAction(x => x.ListUsers());
            }

            return View(nameof(DeleteUser), model);
        }

        private ApplicationUser GetUserOrThrow(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                throw new HttpException(404, "User not found");
            }

            return user;
        }

    }
}