namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v391 : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'Euro 2020');" +
                "DECLARE @MatchId INT;" +
                "" +
                "SET @MatchId = (SELECT Id FROM dbo.Matches WHERE Tournament_Id = @TournamentId AND Stage = 2 AND HomeTeamIsoCode = 'ch' AND AwayTeamIsoCode = 'es');" +
                "UPDATE dbo.Matches SET DateTime = '2021-07-02 18:00:00.000' WHERE Id = @MatchId;" +
                "" +
                "SET @MatchId = (SELECT Id FROM dbo.Matches WHERE Tournament_Id = @TournamentId AND Stage = 2 AND HomeTeamIsoCode = 'be' AND AwayTeamIsoCode = 'it');" +
                "UPDATE dbo.Matches SET DateTime = '2021-07-02 21:00:00.000' WHERE Id = @MatchId;" +
                "" +
                "SET @MatchId = (SELECT Id FROM dbo.Matches WHERE Tournament_Id = @TournamentId AND Stage = 2 AND HomeTeamIsoCode = 'cz' AND AwayTeamIsoCode = 'dk');" +
                "UPDATE dbo.Matches SET DateTime = '2021-07-03 18:00:00.000' WHERE Id = @MatchId;" +
                "" +
                "SET @MatchId = (SELECT Id FROM dbo.Matches WHERE Tournament_Id = @TournamentId AND Stage = 2 AND HomeTeamIsoCode = 'ua' AND AwayTeamIsoCode = '_England');" +
                "UPDATE dbo.Matches SET DateTime = '2021-07-03 21:00:00.000' WHERE Id = @MatchId;" +
                "" +
                ";"
            );
        }
        
        public override void Down()
        {
        }
    }
}
