using System.Collections.Generic;

namespace WaterMeter.ScheduledJob.Models
{
    public class ReminderModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Link { get; set; }
        public List<PropertyModel> Properties { get; set; } = new List<PropertyModel>();
    }
}
