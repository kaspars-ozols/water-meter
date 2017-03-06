using Microsoft.Azure.WebJobs;
using WaterMeter.ScheduledJob.DependencyResolution;
using WaterMeter.ScheduledJob.Infrastructure;

namespace WaterMeter.ScheduledJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    internal static class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        public static void Main()
        {
            var container = IoC.Initialize();
            var config = new JobHostConfiguration
            {
                JobActivator = new ContainerJobActivator(container)
            };

            if (config.IsDevelopment)
                config.UseDevelopmentSettings();
            
            config.UseTimers();

            var host = new JobHost(config);
            host.RunAndBlock();
        }
    }
}