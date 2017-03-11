using Microsoft.Azure.WebJobs.Host;
using StructureMap;

namespace WaterMeter.WebJobs.Infrastructure
{
    public class ContainerJobActivator : IJobActivator
    {
        private readonly IContainer _container;

        public ContainerJobActivator(IContainer container)
        {
            _container = container;
        }

        public T CreateInstance<T>() => _container.GetInstance<T>();
    }
}
