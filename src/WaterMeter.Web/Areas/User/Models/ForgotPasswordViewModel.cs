using System.ComponentModel.DataAnnotations;

namespace WaterMeter.Web.Areas.User.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}