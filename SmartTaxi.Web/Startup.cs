using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartTaxi.Web.Startup))]
namespace SmartTaxi.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
