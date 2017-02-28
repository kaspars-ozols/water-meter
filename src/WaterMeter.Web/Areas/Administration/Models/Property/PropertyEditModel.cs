using System.ComponentModel.DataAnnotations;

namespace WaterMeter.Web.Areas.Administration.Models.Property
{
    public class PropertyEditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }
    }
}