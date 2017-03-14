using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using WaterMeter.Core.Entities;

namespace WaterMeter.Core.Persistance
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
            //Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Meter> Meters { get; set; }
        public DbSet<MeterReading> MeterReadings { get; set; }
    }
}