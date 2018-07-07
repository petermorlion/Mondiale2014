namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v340 : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'WK 2018');" +
                "INSERT INTO dbo.Matches (HomeTeamIsoCode, AwayTeamIsoCode, DateTime, Stage, Tournament_Id)" +
                "VALUES ('fr', 'be', '2018/07/10 20:00', 3, @TournamentId)" +
                ";"
            );
        }

        public override void Down()
        {
            Sql("DELETE FROM dbo.Matches WHERE DateTime >= '2018/07/10'");
        }
    }
}