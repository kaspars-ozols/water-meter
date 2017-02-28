using System.ComponentModel.DataAnnotations;

namespace WaterMeter.Web.Areas.Administration.Models.Property
{
    public class AddressCreateModel
    {
        [Required]
        public string Address { get; set; }
    }
}