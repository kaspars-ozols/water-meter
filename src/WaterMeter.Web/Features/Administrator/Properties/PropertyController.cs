using System.Linq;
using System.Web.Mvc;
using WaterMeter.Core.Constants;
using WaterMeter.Core.Entities;
using WaterMeter.Core.Persistance;

namespace WaterMeter.Web.Features.Administrator.Properties
{
    [Authorize(Roles = Role.Administrator)]
    [RoutePrefix("properties")]
    public class PropertyController : Controller
    {
        [HttpGet]
        [Route("list")]
        public ActionResult ListProperties()
        {
            var model = new PropertyListModel();

            using (var db = new ApplicationDbContext())
            {
                model.Properties = db.Properties
                    .OrderBy(x => x.Address)
                    .Select(x => new PropertyListItemModel
                    {
                        Id = x.Id,
                        Address = x.Address
                    })
                    .ToList();
            }

            return View(nameof(ListProperties), model);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult CreateProperty()
        {
            var model = new PropertyCreateModel();

            return View(nameof(CreateProperty), model);
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProperty(PropertyCreateModel model)
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

                return RedirectToAction(nameof(ListProperties));
            }

            return View(nameof(CreateProperty), model);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult EditProperty(int id)
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

                return View(nameof(EditProperty), model);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditProperty(int id, PropertyEditModel model)
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

                return RedirectToAction(nameof(ListProperties));
            }

            return View(nameof(EditProperty), model);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult DeleteProperty(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var property = db.Properties.FirstOrDefault(x => x.Id == id);

                if (property == null)
                {
                    return HttpNotFound();
                }

                var model = new PropertyDeleteModel
                {
                    Id = property.Id,
                    Address = property.Address
                };

                return View(nameof(DeleteProperty), model);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProperty(int id, PropertyDeleteModel model)
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

                    db.Properties.Remove(property);
                    db.SaveChanges();
                }

                return RedirectToAction(nameof(ListProperties));
            }

            return View(nameof(DeleteProperty), model);
        }
    }
}