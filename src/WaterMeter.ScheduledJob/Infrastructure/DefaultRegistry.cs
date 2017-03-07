using StructureMap;
using WaterMeter.ScheduledJob.Rendering;

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

            For<IRenderer>().Use<RazorRenderer>();
        }
    }
}