using System.Collections.Generic;

namespace WaterMeter.Web.Areas.Administration.Models.Meter
{
    public class MeterListModel
    {
        public List<MeterListItemModel> Addresses { get; set; } = new List<MeterListItemModel>();
    }
}