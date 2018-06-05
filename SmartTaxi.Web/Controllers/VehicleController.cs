using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartTaxi.Web.Data;
using SmartTaxi.Web.Domain;
using SmartTaxi.Web.Domain.Enums;
using SmartTaxi.Web.Models;

namespace SmartTaxi.Web.Controllers
{
    public class VehicleController : Controller
    {
        public ActionResult Index()
        {
            List<Vehicle> allVehicles;

            using (var ctx = new SmartTaxiDbContext())
            {
                allVehicles = ctx.Vehicles.ToList();
            }

            return View(allVehicles);
        }

        [HttpGet]
        public ActionResult NewVehicle()
        {
            return View("NewVehicle", new VehicleViewModel());
        }

        [HttpPost]
        public ActionResult NewVehicle(VehicleViewModel vehicle)
        {
            if (ModelState.IsValid)
            {
                using (var ctx = new SmartTaxiDbContext())
                {
                    ctx.Vehicles.Add(new Vehicle() { RegistrationNumber =  vehicle.RegistrationNumber, Year = vehicle.Year, VehicleType = VehicleType.Limosine });
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View("NewVehicle", vehicle);
        }
    }
}