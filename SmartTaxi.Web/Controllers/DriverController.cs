using System;
using SmartTaxi.Web.Data;
using SmartTaxi.Web.Domain;
using System.Linq;
using System.Web.Mvc;

namespace SmartTaxi.Web.Controllers
{
    public class DriverController : Controller
    {
        private readonly SmartTaxiDbContext _context;

        public DriverController()
        {
            _context = new SmartTaxiDbContext();
        }

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    var allDrivers = _context.Drivers.ToList();

        //    return View(allDrivers);
        //}

        //[HttpGet]
        //public ActionResult New()
        //{
        //    return View(new());
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult SaveNewDriver(Driver newDriver)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Drivers.Add(newDriver);
        //        _context.SaveChanges();

        //        return RedirectToAction("Index");
        //    }

        //    return View("New", newDriver);
        //}

        [HttpGet]
        public ActionResult ViewLocation()
        {
            var location = new Location
            {
                Address = new Address
                {
                    City = "Novi Sad",
                    Street = "Bulevar Vojvode Stepe",
                    Number = "43",
                    ZipCode = "21000"
                }
            };

            return View(location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDriverLocation(string id, Location location)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (ModelState.IsValid)
            {
                // Update the driver location
            }

            return View("ViewLocation", location);
        }
    }
}