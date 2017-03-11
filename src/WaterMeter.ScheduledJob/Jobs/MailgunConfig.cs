using WaterMeter.Core.Helpers;

namespace WaterMeter.ScheduledJob.Jobs
{
    public static class ReminderJobConfig
    {
        private const string Area = "ReminderJob";
        public static string Sender => ConfigHelper.GetValue<string>(Area, nameof(Sender));
    }
}