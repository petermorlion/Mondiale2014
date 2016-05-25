namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v210 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "Tournament_Id", "dbo.Tournaments");
            DropIndex("dbo.Matches", new[] { "Tournament_Id" });
            AlterColumn("dbo.Matches", "Tournament_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Matches", "Tournament_Id");
            AddForeignKey("dbo.Matches", "Tournament_Id", "dbo.Tournaments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "Tournament_Id", "dbo.Tournaments");
            DropIndex("dbo.Matches", new[] { "Tournament_Id" });
            AlterColumn("dbo.Matches", "Tournament_Id", c => c.Int());
            CreateIndex("dbo.Matches", "Tournament_Id");
            AddForeignKey("dbo.Matches", "Tournament_Id", "dbo.Tournaments", "Id");
        }
    }
}
