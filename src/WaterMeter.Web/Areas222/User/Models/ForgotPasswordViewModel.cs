using System.ComponentModel.DataAnnotations;

namespace WaterMeter.Web.Areas222.User.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}