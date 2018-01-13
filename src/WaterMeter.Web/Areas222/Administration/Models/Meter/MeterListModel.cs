using System.Collections.Generic;

namespace WaterMeter.Web.Areas222.Administration.Models.Meter
{
    public class MeterListModel
    {
        public List<MeterListItemModel> Meters { get; set; } = new List<MeterListItemModel>();
    }
}