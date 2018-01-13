using System.Collections.Generic;

namespace WaterMeter.Web.Areas222.Administration.Models.Property
{
    public class PropertyListModel
    {
        public List<PropertyListItemModel> Addresses { get; set; } = new List<PropertyListItemModel>();
    }
}