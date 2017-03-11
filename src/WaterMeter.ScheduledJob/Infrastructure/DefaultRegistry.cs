using StructureMap;
using WaterMeter.ScheduledJob.Rendering;
using WaterMeter.Services.Mail;

namespace WaterMeter.ScheduledJob.DependencyResolution
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
        }
    }
}