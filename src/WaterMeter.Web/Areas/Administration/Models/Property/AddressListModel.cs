using System.Collections.Generic;

namespace WaterMeter.Web.Areas.Administration.Models.Property
{
    public class AddressListModel
    {
        public List<AddressListItemModel> Addresses { get; set; } = new List<AddressListItemModel>();
    }
}