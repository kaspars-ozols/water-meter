using System.ComponentModel.DataAnnotations;

namespace WaterMeter.Web.Areas222.Administration.Models.Property
{
    public class PropertyCreateModel
    {
        [Required]
        public string Address { get; set; }
    }
}