using System.Collections.Generic;

namespace WaterMeter.WebJobs.Models
{
    public class ReminderModel
    {
        public bool SubjectOnly { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Link { get; set; }
        public List<PropertyModel> Properties { get; set; } = new List<PropertyModel>();
    }
}
