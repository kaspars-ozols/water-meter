using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using WaterMeter.Core.Persistance;

namespace WaterMeter.ScheduledJob.Jobs
{
    public class NotificationSendingJob
    {
        private readonly ApplicationDbContext _dbContext;

        public NotificationSendingJob(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Run([TimerTrigger("00:00:10")] TimerInfo timer)
        {
            foreach (var property in _dbContext.Properties)
            {
                Console.WriteLine("Property: {0}", property.Address);
            }

            return Task.FromResult(true);
        }
    }
}