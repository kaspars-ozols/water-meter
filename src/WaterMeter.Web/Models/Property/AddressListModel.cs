using System.Collections.Generic;

namespace WaterMeter.Web.Models.Property
{
    public class AddressListModel
    {
        public List<AddressListItemModel> Addresses { get; set; } = new List<AddressListItemModel>();
    }
}