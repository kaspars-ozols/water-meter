using Microsoft.AspNet.Identity.Owin;
using StructureMap;
using System.Web;

namespace WaterMeter.Web.DependencyResolution
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });

            For<ApplicationUserManager>().Use(() => HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>());
            For<ApplicationSignInManager>().Use(() => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>());
            For<Microsoft.Owin.Security.IAuthenticationManager>().Use(() => HttpContext.Current.GetOwinContext().Authentication);
        }
    }
}