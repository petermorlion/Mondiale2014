namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v390 : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'Euro 2020');" +
                "INSERT INTO dbo.Matches (HomeTeamIsoCode, AwayTeamIsoCode, DateTime, Stage, Tournament_Id)" +
                "VALUES ('ch', 'es', '2020/07/02 18:00', 2, @TournamentId)," +
                "       ('be', 'it', '2020/07/02 21:00', 2, @TournamentId)," +
                "       ('cz', 'dk', '2020/07/03 18:00', 2, @TournamentId)," +
                "       ('ua', '_England', '2020/07/03 21:00', 2, @TournamentId)" +
                ";");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM dbo.Matches WHERE DateTime > '2020/07/02'");
        }
    }
}
