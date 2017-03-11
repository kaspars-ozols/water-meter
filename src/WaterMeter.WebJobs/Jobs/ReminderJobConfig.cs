using WaterMeter.Core.Helpers;

namespace WaterMeter.WebJobs.Jobs
{
    public static class ReminderJobConfig
    {
        private const string Area = "ReminderJob";
        public static string Sender => ConfigHelper.GetValue<string>(Area, nameof(Sender));
    }
}