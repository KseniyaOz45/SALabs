namespace Laba4_Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Hero_Id1", "dbo.Heroes");
            DropIndex("dbo.Orders", new[] { "Hero_Id1" });
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Hero_Id1", c => c.Int());
            AddColumn("dbo.Orders", "Hero_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Hero_Id1");
            AddForeignKey("dbo.Orders", "Hero_Id1", "dbo.Heroes", "Id");
        }
    }
}
