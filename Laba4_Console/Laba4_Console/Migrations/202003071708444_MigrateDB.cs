namespace Laba4_Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ZoneOrders",
                c => new
                    {
                        Zone_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Zone_Id, t.Order_Id })
                .ForeignKey("dbo.Zones", t => t.Zone_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Zone_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZoneOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ZoneOrders", "Zone_Id", "dbo.Zones");
            DropIndex("dbo.ZoneOrders", new[] { "Order_Id" });
            DropIndex("dbo.ZoneOrders", new[] { "Zone_Id" });
            DropTable("dbo.ZoneOrders");
        }
    }
}
