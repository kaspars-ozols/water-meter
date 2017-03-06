using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace WaterMeter.ScheduledJob.Jobs
{
    public class NotificationSendingJob
    {
        public Task Run([TimerTrigger("00:00:30")] TimerInfo timer)
        {
            Console.WriteLine("Injected dependency: {0}", true);

            return Task.FromResult(true);
        }
    }
}