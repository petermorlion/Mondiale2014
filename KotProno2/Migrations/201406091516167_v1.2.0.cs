namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v120 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "HomeScore", c => c.Int(nullable: true));
            AddColumn("dbo.Matches", "AwayScore", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "AwayScore");
            DropColumn("dbo.Matches", "HomeScore");
        }
    }
}
