using StructureMap;

namespace WaterMeter.ScheduledJob.Infrastructure
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(c => c.AddRegistry<DefaultRegistry>());
        }
    }
}
