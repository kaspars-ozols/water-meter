using System.ComponentModel.DataAnnotations;

namespace WaterMeter.Web.Areas.Administration.Models.Meter
{
    public class MeterCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}