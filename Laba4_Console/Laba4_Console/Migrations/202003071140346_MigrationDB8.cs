namespace Laba4_Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Hero_HeroId", c => c.Int());
            CreateIndex("dbo.Orders", "Hero_HeroId");
            AddForeignKey("dbo.Orders", "Hero_HeroId", "dbo.Heroes", "HeroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Hero_HeroId", "dbo.Heroes");
            DropIndex("dbo.Orders", new[] { "Hero_HeroId" });
            DropColumn("dbo.Orders", "Hero_HeroId");
        }
    }
}
