using System;

namespace WaterMeter.Core.Entities
{
    public class MeterReading
    {
        public int Id { get; set; }
        public int MeterId { get; set; }
        public DateTime Time { get; set; }
        public decimal Value { get; set; }
    }
}