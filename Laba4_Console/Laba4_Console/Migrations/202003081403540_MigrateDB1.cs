namespace Laba4_Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ZoneOrders", newName: "OrderZones");
            DropPrimaryKey("dbo.OrderZones");
            CreateTable(
                "dbo.ZoneAtractions",
                c => new
                    {
                        Zone_Id = c.Int(nullable: false),
                        Atraction_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Zone_Id, t.Atraction_Id })
                .ForeignKey("dbo.Zones", t => t.Zone_Id, cascadeDelete: true)
                .ForeignKey("dbo.Atractions", t => t.Atraction_Id, cascadeDelete: true)
                .Index(t => t.Zone_Id)
                .Index(t => t.Atraction_Id);
            
            AddPrimaryKey("dbo.OrderZones", new[] { "Order_Id", "Zone_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZoneAtractions", "Atraction_Id", "dbo.Atractions");
            DropForeignKey("dbo.ZoneAtractions", "Zone_Id", "dbo.Zones");
            DropIndex("dbo.ZoneAtractions", new[] { "Atraction_Id" });
            DropIndex("dbo.ZoneAtractions", new[] { "Zone_Id" });
            DropPrimaryKey("dbo.OrderZones");
            DropTable("dbo.ZoneAtractions");
            AddPrimaryKey("dbo.OrderZones", new[] { "Zone_Id", "Order_Id" });
            RenameTable(name: "dbo.OrderZones", newName: "ZoneOrders");
        }
    }
}
