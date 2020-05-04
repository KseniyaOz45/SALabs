namespace Laba4_Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "HeroId", "dbo.Heroes");
            DropIndex("dbo.Orders", new[] { "HeroId" });
            RenameColumn(table: "dbo.Orders", name: "HeroId", newName: "Hero_Id");
            AddColumn("dbo.Orders", "Hero_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "Hero_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Hero_Id");
            AddForeignKey("dbo.Orders", "Hero_Id", "dbo.Heroes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Hero_Id", "dbo.Heroes");
            DropIndex("dbo.Orders", new[] { "Hero_Id" });
            AlterColumn("dbo.Orders", "Hero_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Hero_Id");
            RenameColumn(table: "dbo.Orders", name: "Hero_Id", newName: "HeroId");
            CreateIndex("dbo.Orders", "HeroId");
            AddForeignKey("dbo.Orders", "HeroId", "dbo.Heroes", "Id", cascadeDelete: true);
        }
    }
}
