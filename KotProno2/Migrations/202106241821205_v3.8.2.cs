namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v382 : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'Euro 2020');" +
                "DECLARE @MatchId INT;" +
                "" +
                "SET @MatchId = (SELECT Id FROM dbo.Matches WHERE Tournament_Id = @TournamentId AND Stage = 1 AND HomeTeamIsoCode = '_Wales' AND AwayTeamIsoCode = 'dk');" +
                "UPDATE dbo.Matches SET DateTime = '2021-06-26 18:00:00.000' WHERE Id = @MatchId;" +
                "" +
                "SET @MatchId = (SELECT Id FROM dbo.Matches WHERE Tournament_Id = @TournamentId AND Stage = 1 AND HomeTeamIsoCode = 'it' AND AwayTeamIsoCode = 'at');" +
                "UPDATE dbo.Matches SET DateTime = '2021-06-26 21:00:00.000' WHERE Id = @MatchId;" +
                "" +
                "SET @MatchId = (SELECT Id FROM dbo.Matches WHERE Tournament_Id = @TournamentId AND Stage = 1 AND HomeTeamIsoCode = 'nl' AND AwayTeamIsoCode = 'cz');" +
                "UPDATE dbo.Matches SET DateTime = '2021-06-27 18:00:00.000' WHERE Id = @MatchId;" +
                "" +
                "SET @MatchId = (SELECT Id FROM dbo.Matches WHERE Tournament_Id = @TournamentId AND Stage = 1 AND HomeTeamIsoCode = 'be' AND AwayTeamIsoCode = 'pt');" +
                "UPDATE dbo.Matches SET DateTime = '2021-06-27 21:00:00.000' WHERE Id = @MatchId;" +
                "" +
                "SET @MatchId = (SELECT Id FROM dbo.Matches WHERE Tournament_Id = @TournamentId AND Stage = 1 AND HomeTeamIsoCode = 'hr' AND AwayTeamIsoCode = 'es');" +
                "UPDATE dbo.Matches SET DateTime = '2021-06-28 18:00:00.000' WHERE Id = @MatchId;" +
                "" +
                "SET @MatchId = (SELECT Id FROM dbo.Matches WHERE Tournament_Id = @TournamentId AND Stage = 1 AND HomeTeamIsoCode = 'fr' AND AwayTeamIsoCode = 'ch');" +
                "UPDATE dbo.Matches SET DateTime = '2021-06-28 21:00:00.000' WHERE Id = @MatchId;" +
                "" +
                "SET @MatchId = (SELECT Id FROM dbo.Matches WHERE Tournament_Id = @TournamentId AND Stage = 1 AND HomeTeamIsoCode = '_England' AND AwayTeamIsoCode = 'de');" +
                "UPDATE dbo.Matches SET DateTime = '2021-06-29 18:00:00.000' WHERE Id = @MatchId;" +
                "" +
                "SET @MatchId = (SELECT Id FROM dbo.Matches WHERE Tournament_Id = @TournamentId AND Stage = 1 AND HomeTeamIsoCode = 'se' AND AwayTeamIsoCode = 'ua');" +
                "UPDATE dbo.Matches SET DateTime = '2021-06-29 21:00:00.000' WHERE Id = @MatchId;" +
                "" +
                ";"
            );
        }
        
        public override void Down()
        {
        }
    }
}
