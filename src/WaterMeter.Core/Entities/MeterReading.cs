using System;

namespace WaterMeter.Core.Entities
{
    public class MeterReading
    {
        public int Id { get; set; }
        public Meter Meter { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }
}