namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v380 : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'Euro 2020');" +
                "INSERT INTO dbo.Matches (HomeTeamIsoCode, AwayTeamIsoCode, DateTime, Stage, Tournament_Id)" +
                "VALUES ('_Wales', 'dk', '2020/06/26 18:00', 1, @TournamentId)," +
                "       ('it', 'at', '2020/06/26 21:00', 1, @TournamentId)," +
                "       ('nl', 'cz', '2020/06/27 18:00', 1, @TournamentId)," +
                "       ('be', 'pt', '2020/06/27 21:00', 1, @TournamentId)," +
                "       ('hr', 'es', '2020/06/28 18:00', 1, @TournamentId)," +
                "       ('fr', 'ch', '2020/06/28 21:00', 1, @TournamentId)," +
                "       ('_England', 'de', '2020/06/29 18:00', 1, @TournamentId)," +
                "       ('se', 'ua', '2018/07/29 21:00', 1, @TournamentId)" +
                ";"
            );
        }

        public override void Down()
        {
            Sql("DELETE FROM dbo.Matches WHERE DateTime > '2020/06/26'");
        }
    }
}
