namespace Laba4_Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Id", "dbo.Heroes");
            DropForeignKey("dbo.OrderZones", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderZones", "Zone_Id", "dbo.Zones");
            DropForeignKey("dbo.Atractions", "ZoneId", "dbo.Zones");
            DropIndex("dbo.Atractions", new[] { "ZoneId" });
            DropIndex("dbo.Orders", new[] { "Id" });
            DropIndex("dbo.OrderZones", new[] { "Order_Id" });
            DropIndex("dbo.OrderZones", new[] { "Zone_Id" });
            DropPrimaryKey("dbo.Atractions");
            DropPrimaryKey("dbo.Zones");
            DropPrimaryKey("dbo.Orders");
            CreateTable(
                "dbo.OrderPrices",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Id)
                .Index(t => t.Id);
            
            AlterColumn("dbo.Atractions", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Zones", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Orders", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Atractions", "Id");
            AddPrimaryKey("dbo.Zones", "Id");
            AddPrimaryKey("dbo.Orders", "Id");
            DropColumn("dbo.Atractions", "Price");
            DropColumn("dbo.Atractions", "ZoneId");
            DropColumn("dbo.Zones", "Price");
            DropColumn("dbo.Orders", "Price");
            DropColumn("dbo.Heroes", "Price");
            DropTable("dbo.OrderZones");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderZones",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Zone_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Zone_Id });
            
            AddColumn("dbo.Heroes", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Zones", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Atractions", "ZoneId", c => c.Int(nullable: false));
            AddColumn("dbo.Atractions", "Price", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderPrices", "Id", "dbo.Orders");
            DropIndex("dbo.OrderPrices", new[] { "Id" });
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Zones");
            DropPrimaryKey("dbo.Atractions");
            AlterColumn("dbo.Orders", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Zones", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Atractions", "Id", c => c.Int(nullable: false));
            DropTable("dbo.OrderPrices");
            AddPrimaryKey("dbo.Orders", "Id");
            AddPrimaryKey("dbo.Zones", "Id");
            AddPrimaryKey("dbo.Atractions", "Id");
            CreateIndex("dbo.OrderZones", "Zone_Id");
            CreateIndex("dbo.OrderZones", "Order_Id");
            CreateIndex("dbo.Orders", "Id");
            CreateIndex("dbo.Atractions", "ZoneId");
            AddForeignKey("dbo.Atractions", "ZoneId", "dbo.Zones", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderZones", "Zone_Id", "dbo.Zones", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderZones", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "Id", "dbo.Heroes", "Id");
        }
    }
}
