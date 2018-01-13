using System.Linq;
using System.Web.Mvc;
using WaterMeter.Core.Constants;
using WaterMeter.Core.Entities;
using WaterMeter.Core.Persistance;
using WaterMeter.Web.Areas222.Administration.Models.Property;

namespace WaterMeter.Web.Areas222.Administration.Controllers
{
    [Authorize(Roles = Role.Administrator)]
    [RouteArea(nameof(Administration), AreaPrefix = "")]
    [RoutePrefix("property")]
    public class PropertyController : Controller
    {
        [HttpGet]
        [Route("list")]
        public ActionResult List()
        {
            var model = new PropertyListModel();

            using (var db = new ApplicationDbContext())
            {
                model.Addresses = db.Properties
                    .OrderBy(x => x.Address)
                    .Select(x => new PropertyListItemModel
                    {
                        Id = x.Id,
                        Address = x.Address
                    })
                    .ToList();
            }

            return View(model);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            var model = new PropertyCreateModel();

            return View(model);
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(PropertyCreateModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var property = new Property
                    {
                        Address = model.Address
                    };

                    db.Properties.Add(property);
                    db.SaveChanges();
                }
                return RedirectToAction(nameof(List));
            }

            return View();
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var address = db.Properties.FirstOrDefault(x => x.Id == id);

                if (address == null)
                {
                    return HttpNotFound();
                }

                var model = new PropertyEditModel
                {
                    Id = address.Id,
                    Address = address.Address
                };

                return View(model);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        public ActionResult Edit(int id, PropertyEditModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var property = db.Properties.FirstOrDefault(x => x.Id == model.Id);

                    if (property == null)
                    {
                        return HttpNotFound();
                    }

                    property.Address = model.Address;

                    db.SaveChanges();
                }

                return RedirectToAction(nameof(List));
            }

            return View();
        }
    }
}