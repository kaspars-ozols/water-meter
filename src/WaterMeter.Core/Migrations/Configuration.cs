using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using WaterMeter.Core.Constants;
using WaterMeter.Core.Persistance;

namespace WaterMeter.Core.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Roles.AddOrUpdate(
                role => role.Id,
              new IdentityRole { Id = "1", Name = Role.Administrator },
              new IdentityRole { Id = "2", Name = Role.Accountant },
              new IdentityRole { Id = "3", Name = Role.User }
            );

        }
}
}