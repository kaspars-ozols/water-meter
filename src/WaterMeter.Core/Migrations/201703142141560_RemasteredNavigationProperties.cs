namespace WaterMeter.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemasteredNavigationProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meters", "PropertyId", "dbo.Properties");
            DropIndex("dbo.Meters", new[] { "PropertyId" });
            RenameColumn(table: "dbo.Meters", name: "PropertyId", newName: "Property_Id");
            CreateTable(
                "dbo.ApplicationUserProperties",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Property_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Property_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.Property_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Property_Id);
            
            AddColumn("dbo.MeterReadings", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.MeterReadings", "Meter_Id", c => c.Int());
            AddColumn("dbo.Properties", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Meters", "Property_Id", c => c.Int());
            CreateIndex("dbo.MeterReadings", "Meter_Id");
            CreateIndex("dbo.Meters", "Property_Id");
            AddForeignKey("dbo.MeterReadings", "Meter_Id", "dbo.Meters", "Id");
            AddForeignKey("dbo.Meters", "Property_Id", "dbo.Properties", "Id");
            DropColumn("dbo.MeterReadings", "MeterId");
            DropColumn("dbo.MeterReadings", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MeterReadings", "Time", c => c.DateTime(nullable: false));
            AddColumn("dbo.MeterReadings", "MeterId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Meters", "Property_Id", "dbo.Properties");
            DropForeignKey("dbo.MeterReadings", "Meter_Id", "dbo.Meters");
            DropForeignKey("dbo.ApplicationUserProperties", "Property_Id", "dbo.Properties");
            DropForeignKey("dbo.ApplicationUserProperties", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserProperties", new[] { "Property_Id" });
            DropIndex("dbo.ApplicationUserProperties", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Meters", new[] { "Property_Id" });
            DropIndex("dbo.MeterReadings", new[] { "Meter_Id" });
            AlterColumn("dbo.Meters", "Property_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Properties", "IsActive");
            DropColumn("dbo.MeterReadings", "Meter_Id");
            DropColumn("dbo.MeterReadings", "Date");
            DropTable("dbo.ApplicationUserProperties");
            RenameColumn(table: "dbo.Meters", name: "Property_Id", newName: "PropertyId");
            CreateIndex("dbo.Meters", "PropertyId");
            AddForeignKey("dbo.Meters", "PropertyId", "dbo.Properties", "Id", cascadeDelete: true);
        }
    }
}
