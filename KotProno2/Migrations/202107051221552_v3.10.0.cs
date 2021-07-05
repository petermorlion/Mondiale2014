namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3100 : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'Euro 2020');" +
                "INSERT INTO dbo.Matches (HomeTeamIsoCode, AwayTeamIsoCode, DateTime, Stage, Tournament_Id)" +
                "VALUES ('it', 'es', '2021/07/06 21:00', 3, @TournamentId)," +
                "       ('_England', 'dk', '2021/07/07 21:00', 3, @TournamentId)" +
                ";");
        }

        public override void Down()
        {
            Sql("DELETE FROM dbo.Matches WHERE DateTime > '2021/07/05'");
        }
    }
}
