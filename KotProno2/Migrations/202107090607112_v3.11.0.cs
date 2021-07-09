namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3110 : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @TournamentId INT;" +
                   "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'Euro 2020');" +
                   "INSERT INTO dbo.Matches (HomeTeamIsoCode, AwayTeamIsoCode, DateTime, Stage, Tournament_Id)" +
                   "VALUES ('it', '_England', '2021/07/11 21:00', 4, @TournamentId)" +
                   ";");
        }

        public override void Down()
        {
            Sql("DELETE FROM dbo.Matches WHERE DateTime > '2021/07/10'");
        }
    }
}
