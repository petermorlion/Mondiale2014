namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v240 : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'EK 2016');" +
                "INSERT INTO dbo.Matches (HomeTeamIsoCode, AwayTeamIsoCode, DateTime, Stage, IsReadOnly, Tournament_Id)" +
                "VALUES ('ch', 'pl', '2016/06/25 15:00', 1, 0, @TournamentId)," +
                "       ('_Wales', '_Northern_Ireland', '2016/06/25 18:00', 1, 0, @TournamentId)," +
                "       ('hr', 'pt', '2016/06/25 21:00', 1, 0, @TournamentId)," +

                "       ('fr', 'ie', '2016/06/26 15:00', 1, 0, @TournamentId)," +
                "       ('de', 'sk', '2016/06/26 18:00', 1, 0, @TournamentId)," +
                "       ('hu', 'be', '2016/06/26 21:00', 1, 0, @TournamentId)," +

                "       ('it', 'es', '2016/06/27 18:00', 1, 0, @TournamentId)," +
                "       ('_England', 'is', '2016/06/27 21:00', 1, 0, @TournamentId)" +
                ";"
                );
        }
        
        public override void Down()
        {
            Sql("DELETE FROM dbo.Matches WHERE DateTime > '2016/06/25'");
        }
    }
}
