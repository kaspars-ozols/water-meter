using System.ComponentModel.DataAnnotations;

namespace WaterMeter.Web.Areas222.User.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}