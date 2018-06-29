namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v320 : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'WK 2018');" +
                "INSERT INTO dbo.Matches (HomeTeamIsoCode, AwayTeamIsoCode, DateTime, Stage, Tournament_Id)" +
                "VALUES ('fr', 'ar', '2018/06/30 16:00', 1, @TournamentId)," +
                "       ('uy', 'pt', '2018/06/30 20:00', 1, @TournamentId)," +
                "       ('es', 'ru', '2018/07/01 16:00', 1, @TournamentId)," +
                "       ('hr', 'dk', '2018/07/01 20:00', 1, @TournamentId)," +
                "       ('br', 'mx', '2018/07/02 16:00', 1, @TournamentId)," +
                "       ('be', 'jp', '2018/07/02 20:00', 1, @TournamentId)," +
                "       ('se', 'ch', '2018/07/03 16:00', 1, @TournamentId)," +
                "       ('co', '_England', '2018/07/03 20:00', 1, @TournamentId)" +
                ";"
            );
        }

        public override void Down()
        {
            Sql("DELETE FROM dbo.Matches WHERE DateTime > '2018/06/29'");
        }
    }
}
