namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v280 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TopScorers", "IsCorrect", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TopScorers", "IsCorrect");
        }
    }
}
