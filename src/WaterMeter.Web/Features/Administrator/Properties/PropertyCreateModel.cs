using System.ComponentModel.DataAnnotations;

namespace WaterMeter.Web.Features.Administrator.Properties
{
    public class PropertyCreateModel
    {
        [Required]
        public string Address { get; set; }
    }
}