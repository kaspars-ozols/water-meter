using System.ComponentModel.DataAnnotations;

namespace WaterMeter.Web.Areas222.User.Models
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}