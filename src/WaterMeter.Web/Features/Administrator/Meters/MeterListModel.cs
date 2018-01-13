using System.Collections.Generic;

namespace WaterMeter.Web.Features.Administrator.Meters
{
    public class MeterListModel
    {
        public List<MeterListItemModel> Meters { get; set; } = new List<MeterListItemModel>();
    }
}