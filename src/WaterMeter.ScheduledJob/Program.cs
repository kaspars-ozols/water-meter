using Microsoft.Azure.WebJobs;

namespace WaterMeter.ScheduledJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    internal static class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        public static void Main()
        {
            var config = new JobHostConfiguration();

            if (config.IsDevelopment)
                config.UseDevelopmentSettings();
            
            config.UseTimers();

            var host = new JobHost(config);
            host.RunAndBlock();
        }
    }
}