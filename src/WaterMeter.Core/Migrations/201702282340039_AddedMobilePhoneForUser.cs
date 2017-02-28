namespace WaterMeter.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMobilePhoneForUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MobilePhone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "MobilePhone");
        }
    }
}
