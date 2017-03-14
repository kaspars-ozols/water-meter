using System;

namespace WaterMeter.WebJobs.Models
{
    public class MeterModel
    {
        public string SerialNumber { get; set; }
        public decimal? LastReadingValue { get; set; }
        public DateTime? LastReadingDate { get; set; }
    }
}