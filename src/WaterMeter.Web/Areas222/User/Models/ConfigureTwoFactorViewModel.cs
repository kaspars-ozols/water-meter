using System.Collections.Generic;
using System.Web.Mvc;

namespace WaterMeter.Web.Areas222.User.Models
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<SelectListItem> Providers { get; set; }
    }
}