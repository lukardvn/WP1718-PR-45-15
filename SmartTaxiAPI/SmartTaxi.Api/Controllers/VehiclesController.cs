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

namespace SmartTaxi.Api.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    [RoutePrefix("api/Vehicles")]
    public class VehiclesController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;
        private readonly SmartTaxiDbContext _context;

        public VehiclesController()
        {
            _context = new SmartTaxiDbContext();
        }

        public VehiclesController(ApplicationUserManager userManager,
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
            var allVehicles = _context.Vehicles.ToList();
           
            return Json(allVehicles);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [Route("New")]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        public async Task<IHttpActionResult> Post([FromBody]Vehicle vehicle)
        {
           
            vehicle.CreatedBy = User.Identity.GetUserId();
            _context.Vehicles.Add(vehicle);
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
