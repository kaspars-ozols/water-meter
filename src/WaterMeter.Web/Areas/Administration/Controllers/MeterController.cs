using System.Linq;
using System.Web.Mvc;
using WaterMeter.Core.Constants;
using WaterMeter.Core.Entities;
using WaterMeter.Core.Persistance;
using WaterMeter.Web.Areas.Administration.Models.Meter;

namespace WaterMeter.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = Role.Administrator)]
    [RouteArea(nameof(Administration), AreaPrefix = "")]
    [RoutePrefix("meter")]
    public class MeterController : Controller
    {
        [HttpGet]
        [Route("list")]
        public ActionResult List()
        {
            var model = new MeterListModel();

            using (var db = new ApplicationDbContext())
            {
                model.Meters = db.Meters
                    .Select(x => new MeterListItemModel
                    {
                        Id = x.Id,
                        SerialNumber = x.SerialNumber,
                        PropertyName = x.Property.Name
                    })
                    .ToList();
            }

            return View(model);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            var model = new MeterCreateModel();

            return View(model);
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(MeterCreateModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var meter = new Meter
                    {
                        Name = model.Name
                    };

                    db.Meters.Add(meter);
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
                    return HttpNotFound();

                var model = new MeterEditModel
                {
                    Id = address.Id,
                    Address = address.Address
                };

                return View(model);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        public ActionResult Edit(int id, MeterEditModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var meter = db.Properties.FirstOrDefault(x => x.Id == model.Id);

                    if (meter == null)
                        return HttpNotFound();

                    meter.Address = model.Address;

                    db.SaveChanges();
                }

                return RedirectToAction(nameof(List));
            }

            return View();
        }
    }
}