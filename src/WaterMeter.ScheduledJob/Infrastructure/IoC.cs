using StructureMap;
using WaterMeter.ScheduledJob.Infrastructure;

namespace WaterMeter.ScheduledJob.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(c => c.AddRegistry<DefaultRegistry>());
        }
    }
}
