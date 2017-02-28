using System.ComponentModel.DataAnnotations;

namespace WaterMeter.Web.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}