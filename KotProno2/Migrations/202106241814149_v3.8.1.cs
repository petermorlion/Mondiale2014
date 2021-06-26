namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v381 : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'Euro 2020');" +
                "DECLARE @MatchId INT;" +
                "SET @MatchId = (SELECT Id FROM dbo.Matches WHERE Tournament_Id = @TournamentId AND Stage = 1 AND HomeTeamIsoCode = 'se' AND AwayTeamIsoCode = 'ua');" +
                "UPDATE dbo.Matches SET DateTime = '2020-07-29 21:00:00.000' WHERE Id = @MatchId" +
                ";"
            );
        }
        
        public override void Down()
        {
        }
    }
}
