using System.ComponentModel.DataAnnotations;

namespace WaterMeter.Web.Areas222.Administration.Models.Property
{
    public class PropertyEditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }
    }
}