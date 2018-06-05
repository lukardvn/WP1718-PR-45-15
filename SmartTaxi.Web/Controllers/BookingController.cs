using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SmartTaxi.Web.Data;
using SmartTaxi.Web.Domain;
using SmartTaxi.Web.Domain.Enums;
using SmartTaxi.Web.Models;
using SmartTaxi.Web.Models.ViewModels;

namespace SmartTaxi.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly SmartTaxiDbContext _context;
        private readonly ApplicationUserManager _userManager;
        
        public BookingController()
        {
            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            _context = new SmartTaxiDbContext();
        }

        public ActionResult Index()
        {
            var allBookings = _context
                .Bookings
                .Include("PickUpLocation")
                .ToList();

            return View(allBookings);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View(new Booking());
        }

        public ActionResult Cancel(string id)
        {
            var bookingViewModel = new CancelBookingViewModel()
            {
                Booking = _context
                    .Bookings
                    .Include("PickUpLocation")
                    .FirstOrDefault(b => b.Id.ToString() == id)
            };

            //var bookingViewModel = new CancelBookingViewModel()
            //{
            //    Booking = new Booking()
            //    {
            //        CreatedAt = DateTime.Now,
            //        PickUpLocation = new Location()
            //        {
            //            Address = new Address()
            //            {
            //                City = "Novi Sad",
            //                Street = "Jase Tomica",
            //                Number = "2",
            //                ZipCode = "21000"
            //            }
            //        }
            //    }
            //};

            return View(bookingViewModel);
        }

        public ActionResult CancelPost(CancelBookingViewModel model)
        {
          return RedirectToAction("Index");
        }

        public ActionResult Finalize(string id)
        {
            var viewModel = new FinalizeBookingViewModel();

            return View(viewModel);
        }

        public ActionResult FinalizePost(FinalizeBookingViewModel model)
        {
            // Update status of the booking

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult NewBookingPost(Booking booking)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                //var role = _userManager.GetRoles(userId);

                //switch (role.First())
                //{
                //    case "Driver":
                //        booking.DriverId = userId;
                //        break;
                //    case "Dispatcher":
                //        booking.DispatcherId = userId;
                //        break;
                //    case "Customer":
                //        booking.CustomerId = userId;
                //        break;
                //}

                booking.CreatedAt = DateTime.Now;
                booking.Status = BookingStatus.Kreirana;

                _context.Bookings.Add(booking);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("New", booking);
        }
    }
}