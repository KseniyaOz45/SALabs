namespace Laba4_Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB6 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Heroes");
            AddColumn("dbo.Heroes", "HeroId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Orders", "Hero_HeroId", c => c.Int());
            AddPrimaryKey("dbo.Heroes", "HeroId");
            CreateIndex("dbo.Orders", "Hero_HeroId");
            AddForeignKey("dbo.Orders", "Hero_HeroId", "dbo.Heroes", "HeroId");
            DropColumn("dbo.Heroes", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Heroes", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Orders", "Hero_HeroId", "dbo.Heroes");
            DropIndex("dbo.Orders", new[] { "Hero_HeroId" });
            DropPrimaryKey("dbo.Heroes");
            DropColumn("dbo.Orders", "Hero_HeroId");
            DropColumn("dbo.Heroes", "HeroId");
            AddPrimaryKey("dbo.Heroes", "Id");
        }
    }
}
