namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v230 : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'EK 2016');" + "" +
                "UPDATE dbo.Matches SET DateTime = '2016/06/11 15:00' WHERE Tournament_Id = @TournamentId AND HomeTeamIsoCode = 'al' AND AwayTeamIsoCode = 'ch' AND DateTime = '2016/06/11 18:00';");

            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'EK 2016');" +
                "INSERT INTO dbo.Matches (HomeTeamIsoCode, AwayTeamIsoCode, DateTime, Stage, IsReadOnly, Tournament_Id)" +
                "VALUES ('tr', 'hr', '2016/06/12 15:00', 0, 0, @TournamentId)," +
                "       ('pl', '_Northern_Ireland', '2016/06/12 18:00', 0, 0, @TournamentId)," +
                "       ('de', 'ua', '2016/06/12 21:00', 0, 0, @TournamentId)," +
                
                "       ('es', 'cz', '2016/06/13 15:00', 0, 0, @TournamentId)," +
                "       ('ie', 'se', '2016/06/13 18:00', 0, 0, @TournamentId)," +
                "       ('be', 'it', '2016/06/13 21:00', 0, 0, @TournamentId)," +

                "       ('at', 'hu', '2016/06/14 18:00', 0, 0, @TournamentId)," +
                "       ('pt', 'is', '2016/06/14 21:00', 0, 0, @TournamentId)," +

                "       ('ru', 'sk', '2016/06/15 15:00', 0, 0, @TournamentId)," +
                "       ('ro', 'ch', '2016/06/15 18:00', 0, 0, @TournamentId)," +
                "       ('fr', 'al', '2016/06/15 21:00', 0, 0, @TournamentId)," +

                "       ('_England', '_Wales', '2016/06/16 15:00', 0, 0, @TournamentId)," +
                "       ('ua', '_Northern_Ireland', '2016/06/16 18:00', 0, 0, @TournamentId)," +
                "       ('de', 'pl', '2016/06/16 21:00', 0, 0, @TournamentId)," +

                "       ('it', 'se', '2016/06/17 15:00', 0, 0, @TournamentId)," +
                "       ('cz', 'hr', '2016/06/17 18:00', 0, 0, @TournamentId)," +
                "       ('es', 'tr', '2016/06/17 21:00', 0, 0, @TournamentId)," +

                "       ('be', 'ie', '2016/06/18 15:00', 0, 0, @TournamentId)," +
                "       ('is', 'hu', '2016/06/18 18:00', 0, 0, @TournamentId)," +
                "       ('pt', 'at', '2016/06/18 21:00', 0, 0, @TournamentId)," +

                "       ('ch', 'fr', '2016/06/19 21:00', 0, 0, @TournamentId)," +
                "       ('ro', 'al', '2016/06/19 21:00', 0, 0, @TournamentId)," +

                "       ('sk', '_England', '2016/06/20 21:00', 0, 0, @TournamentId)," +
                "       ('ru', '_Wales', '2016/06/20 21:00', 0, 0, @TournamentId)," +

                "       ('_Northern_Ireland', 'de', '2016/06/21 18:00', 0, 0, @TournamentId)," +
                "       ('ua', 'pl', '2016/06/21 18:00', 0, 0, @TournamentId)," +
                "       ('hr', 'es', '2016/06/21 21:00', 0, 0, @TournamentId)," +
                "       ('cz', 'tr', '2016/06/21 21:00', 0, 0, @TournamentId)," +

                "       ('is', 'at', '2016/06/22 18:00', 0, 0, @TournamentId)," +
                "       ('hu', 'pt', '2016/06/22 18:00', 0, 0, @TournamentId)," +
                "       ('se', 'be', '2016/06/22 21:00', 0, 0, @TournamentId)," +
                "       ('it', 'ie', '2016/06/22 21:00', 0, 0, @TournamentId)" +
                ";"
                );
        }
        
        public override void Down()
        {
            Sql("DELETE FROM dbo.Matches WHERE DateTime > '2016/06/12'");
        }
    }
}
