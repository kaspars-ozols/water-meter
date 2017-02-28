using System.Collections.Generic;

namespace WaterMeter.Web.Models.Property
{
    public class AddressListModel
    {
        public List<ListItemModel> Addresses { get; set; } = new List<ListItemModel>();
    }
}