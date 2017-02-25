using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WaterMeter.Startup))]
namespace WaterMeter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
