using System.ComponentModel.DataAnnotations;

namespace WaterMeter.Web.Models.Property
{
    public class AddressCreateModel
    {
        [Required]
        public string Address { get; set; }
    }
}