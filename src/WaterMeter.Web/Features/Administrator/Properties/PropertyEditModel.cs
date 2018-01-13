using System.ComponentModel.DataAnnotations;

namespace WaterMeter.Web.Features.Administrator.Properties
{
    public class PropertyEditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }
    }

    public class PropertyDeleteModel
    {
        public int Id { get; set; }

        public string Address { get; set; }
    }
}