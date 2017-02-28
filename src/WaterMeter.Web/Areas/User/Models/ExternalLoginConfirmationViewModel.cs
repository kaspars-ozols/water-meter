using System.ComponentModel.DataAnnotations;

namespace WaterMeter.Web.Areas.User.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}