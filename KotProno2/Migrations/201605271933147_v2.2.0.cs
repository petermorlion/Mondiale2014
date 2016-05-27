namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v220 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TopScorers", "TournamentId", c => c.String());

            Sql("UPDATE dbo.TopScorers SET TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'WK 2014')");
        }
        
        public override void Down()
        {
            DropColumn("dbo.TopScorers", "TournamentId");
        }
    }
}
