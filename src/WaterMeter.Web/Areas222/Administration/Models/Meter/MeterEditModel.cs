using System.ComponentModel.DataAnnotations;

namespace WaterMeter.Web.Areas222.Administration.Models.Meter
{
    public class MeterEditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }
    }
}