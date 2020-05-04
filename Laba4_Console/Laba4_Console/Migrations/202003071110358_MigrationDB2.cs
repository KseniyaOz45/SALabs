namespace Laba4_Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Hero_Id", "dbo.Heroes");
            DropIndex("dbo.Orders", new[] { "Hero_Id" });
            RenameColumn(table: "dbo.Orders", name: "Hero_Id", newName: "HeroId");
            AlterColumn("dbo.Orders", "HeroId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "HeroId");
            AddForeignKey("dbo.Orders", "HeroId", "dbo.Heroes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "HeroId", "dbo.Heroes");
            DropIndex("dbo.Orders", new[] { "HeroId" });
            AlterColumn("dbo.Orders", "HeroId", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "HeroId", newName: "Hero_Id");
            CreateIndex("dbo.Orders", "Hero_Id");
            AddForeignKey("dbo.Orders", "Hero_Id", "dbo.Heroes", "Id");
        }
    }
}
