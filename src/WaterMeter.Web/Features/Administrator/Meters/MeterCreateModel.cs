using System.ComponentModel.DataAnnotations;

namespace WaterMeter.Web.Features.Administrator.Meters
{
    public class MeterCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}