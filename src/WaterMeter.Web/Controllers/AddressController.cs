using System.Linq;
using System.Web.Mvc;
using WaterMeter.Core.Entities;
using WaterMeter.Core.Persistance;
using WaterMeter.Web.Models.Property;

namespace WaterMeter.Web.Controllers
{

    [RoutePrefix("address")]
    public class AddressController : Controller
    {
        [HttpGet]
        [Route("list")]
        public ActionResult List()
        {
            var model = new AddressListModel();

            using (var db = new ApplicationDbContext())
            {
                model.Addresses = db.Addresses
                    .OrderBy(x => x.Address)
                    .Select(x => new ListItemModel
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
            var model = new AddressCreateModel();

            return View(model);
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(AddressCreateModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var property = new Property
                    {
                        Address = model.Address
                    };

                    db.Addresses.Add(property);
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }

            return View();
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var address = db.Addresses.FirstOrDefault(x => x.Id == id);

                if (address == null)
                    return HttpNotFound();

                var model = new AddressEditModel
                {
                    Id = address.Id,
                    Address = address.Address
                };

                return View(model);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        public ActionResult Edit(int id, AddressEditModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var property = db.Addresses.FirstOrDefault(x => x.Id == model.Id);

                    if (property == null)
                        return HttpNotFound();

                    property.Address = model.Address;

                    db.SaveChanges();
                }

                return RedirectToAction(nameof(List));
            }

            return View();
        }
    }
}