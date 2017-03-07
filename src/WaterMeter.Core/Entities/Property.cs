using System.Collections.Generic;

namespace WaterMeter.Core.Entities
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<Meter> Meters { get; set; }
        public bool IsActive { get; set; }
    }
}