using System;
using SmartTaxi.Api.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SmartTaxi.Api.Data;
using SmartTaxi.Api.Models;

namespace SmartTaxi.Api.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    [RoutePrefix("api/Bookings")]
    public class BookingsController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;
        private readonly SmartTaxiDbContext _context;

        public BookingsController()
        {
            _context = new SmartTaxiDbContext();
        }

        public BookingsController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        // GET api/vehicles
        public IHttpActionResult Get()
        {
            var allBookings = _context
                .Bookings
                .Include("PickUpLocation")
                .ToList();
           
            return Json(allBookings);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [Route("New")]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        public async Task<IHttpActionResult> Post([FromBody]AddBookingViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var roles = UserManager.GetRoles(userId);
            
            var booking = new Booking
            {
                CustomerId = User.Identity.GetUserId(),
                CreatedAt = DateTime.Now,
                PickUpLocation = new Location { Address = new Address
                {
                    Street = model.Street,
                    Number = model.Number,
                    City = model.City,
                    ZipCode = model.ZipCode
                }}
            };

            switch (roles.First())
            {
                case "Dispatcher":
                    booking.DispatcherId = userId;
                    break;
                case "Customer":
                    booking.CustomerId = userId;
                    break;
            }

            _context.Bookings.Add(booking);
            var result = await _context.SaveChangesAsync();

            return Ok();
           
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Vehicle vehicle)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {

        }
    }
}
