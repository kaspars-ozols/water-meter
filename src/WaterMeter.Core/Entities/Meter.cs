using System.Collections.Generic;

namespace WaterMeter.Core.Entities
{
    public class Meter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public Property Property { get; set; }
        public ICollection<MeterReading> Readings { get; set; }
    }
}