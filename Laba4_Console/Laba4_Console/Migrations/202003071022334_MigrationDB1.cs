namespace Laba4_Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Hero_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Hero_Id");
            AddForeignKey("dbo.Orders", "Hero_Id", "dbo.Heroes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Hero_Id", "dbo.Heroes");
            DropIndex("dbo.Orders", new[] { "Hero_Id" });
            DropColumn("dbo.Orders", "Hero_Id");
        }
    }
}
