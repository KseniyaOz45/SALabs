namespace Laba4_Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Hero_HeroId", "dbo.Heroes");
            DropIndex("dbo.Orders", new[] { "Hero_HeroId" });
            DropColumn("dbo.Orders", "Hero_HeroId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Hero_HeroId", c => c.Int());
            CreateIndex("dbo.Orders", "Hero_HeroId");
            AddForeignKey("dbo.Orders", "Hero_HeroId", "dbo.Heroes", "HeroId");
        }
    }
}
