using System.Collections.Generic;

namespace WaterMeter.ScheduledJob.Models
{
    public class PropertyModel
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public List<MeterModel> Meters { get; set; } = new List<MeterModel>();
    }
}