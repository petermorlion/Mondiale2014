namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v375 : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'EK 2021');" +
                "UPDATE dbo.Matches SET AwayTeamIsoCode = 'tr' WHERE AwayTeamIsoCode = 'tk' AND Tournament_Id = @TournamentId" +

                ";"
                );
        }
        
        public override void Down()
        {
        }
    }
}
