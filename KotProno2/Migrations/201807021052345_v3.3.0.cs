namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v330 : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'WK 2018');" +
                "INSERT INTO dbo.Matches (HomeTeamIsoCode, AwayTeamIsoCode, DateTime, Stage, Tournament_Id)" +
                "VALUES ('uy', 'fr', '2018/07/06 16:00', 2, @TournamentId)," +
                "       ('br', 'be', '2018/07/06 20:00', 2, @TournamentId)," +
                "       ('se', '_England', '2018/07/07 16:00', 2, @TournamentId)," +
                "       ('ru', 'hr', '2018/07/07 20:00', 2, @TournamentId)" +
                ";"
            );
        }

        public override void Down()
        {
            Sql("DELETE FROM dbo.Matches WHERE DateTime >= '2018/07/06'");
        }
    }
}
