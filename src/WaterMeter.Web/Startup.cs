using Microsoft.Owin;
using Owin;
using WaterMeter.Web;

[assembly: OwinStartup(typeof(Startup))]

namespace WaterMeter.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}