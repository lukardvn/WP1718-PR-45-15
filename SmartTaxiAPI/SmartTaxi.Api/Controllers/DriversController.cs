using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SmartTaxi.Api.Data;
using SmartTaxi.Api.Models;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SmartTaxi.Api.Entities;

namespace SmartTaxi.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Drivers")]
    public class DriversController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;
        private readonly SmartTaxiDbContext _context;

        public DriversController()
        {
            _context = new SmartTaxiDbContext();
        }

        public DriversController(ApplicationUserManager userManager,
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
            var allDrivers = UserManager.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains("3")).ToList();

            return Json(allDrivers);
        }

        public string Get(int id)
        {
            return "value";
        }

        [Route("New")]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        public async Task<IHttpActionResult> Post([FromBody]NewDriverViewModel driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser()
            {
                UserName = driver.UserName,
                Email = driver.Email,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Gender = driver.Gender,
                Jmbg = driver.Jmbg,
                Telephone = driver.Telephone
            };

            IdentityResult result = await UserManager.CreateAsync(user, driver.Password);

            if (!result.Succeeded)
            {
                
                return GetErrorResult(result);
            }
            UserManager.AddToRole(user.Id, "Driver");

            return Ok();

        }

        [Route("UpdateLocation")]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        public async Task<IHttpActionResult> UpdateDriverLocation([FromBody] Location location)
        {
            return Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
