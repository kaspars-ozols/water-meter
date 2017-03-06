namespace WaterMeter.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInDbModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meters", "SerialNumber", c => c.String());
            AddColumn("dbo.Properties", "Name", c => c.String());
            CreateIndex("dbo.Meters", "PropertyId");
            AddForeignKey("dbo.Meters", "PropertyId", "dbo.Properties", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meters", "PropertyId", "dbo.Properties");
            DropIndex("dbo.Meters", new[] { "PropertyId" });
            DropColumn("dbo.Properties", "Name");
            DropColumn("dbo.Meters", "SerialNumber");
        }
    }
}
