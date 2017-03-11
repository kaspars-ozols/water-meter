using Microsoft.AspNetCore.Razor;
using StructureMap;
using WaterMeter.Services.Mail;
using WaterMeter.Services.Templating;

namespace WaterMeter.ScheduledJob.Infrastructure
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
                });

            For<IMailService>().Use<MailgunMailService>();
            For<ITemplateRenderer>().Use<RazorTemplateRenderer>();
        }
    }
}