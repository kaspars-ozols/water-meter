using System.ComponentModel.DataAnnotations;

namespace WaterMeter.Web.Features.Administrator.Meters
{
    public class MeterEditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }
    }
}