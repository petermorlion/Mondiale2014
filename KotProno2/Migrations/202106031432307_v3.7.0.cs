namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v370 : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM dbo.Tournaments WHERE Name = 'EK 2021'");


            Sql("INSERT INTO dbo.Tournaments(Name) VALUES('EK 2021');");
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'EK 2021');" +
                "INSERT INTO dbo.Matches (HomeTeamIsoCode, AwayTeamIsoCode, DateTime, Stage, Tournament_Id) " +
                "VALUES ('tr', 'it', '2021/06/11 21:00', 0, @TournamentId)," +

                "       ('_Wales', 'ch', '2021/06/12 15:00', 0, @TournamentId)," +
                "       ('dk', 'fi', '2021/06/12 18:00', 0, @TournamentId)," +
                "       ('be', 'ru', '2021/06/12 21:00', 0, @TournamentId)," +
                
                "       ('_Englang', 'hr', '2021/06/13 15:00', 0, @TournamentId)," +
                "       ('at', 'mk', '2021/06/13 18:00', 0, @TournamentId)," +
                "       ('nl', 'ua', '2021/06/13 21:00', 0, @TournamentId)," +

                "       ('_Scotland', 'cz', '2021/06/14 15:00', 0, @TournamentId)," +
                "       ('pl', 'sk', '2021/06/14 18:00', 0, @TournamentId)," +
                "       ('es', 'se', '2021/06/14 21:00', 0, @TournamentId)," +

                "       ('hu', 'pt', '2021/06/15 18:00', 0, @TournamentId)," +
                "       ('fr', 'de', '2021/06/15 21:00', 0, @TournamentId)," +

                "       ('fi', 'ru', '2021/06/16 15:00', 0, @TournamentId)," +
                "       ('tr', '_Wales', '2021/06/16 18:00', 0, @TournamentId)," +
                "       ('it', 'ch', '2021/06/16 21:00', 0, @TournamentId)," +

                "       ('ua', 'mk', '2021/06/17 15:00', 0, @TournamentId)," +
                "       ('dk', 'be', '2021/06/17 18:00', 0, @TournamentId)," +
                "       ('nl', 'at', '2021/06/17 21:00', 0, @TournamentId)," +

                "       ('se', 'sk', '2021/06/18 15:00', 0, @TournamentId)," +
                "       ('hr', 'cz', '2021/06/18 18:00', 0, @TournamentId)," +
                "       ('_England', '_Scotland', '2021/06/18 21:00', 0, @TournamentId)," +

                "       ('hu', 'fr', '2021/06/19 15:00', 0, @TournamentId)," +
                "       ('pt', 'de', '2021/06/19 18:00', 0, @TournamentId)," +
                "       ('es', 'pl', '2021/06/19 21:00', 0, @TournamentId)," +

                "       ('it', '_Wales', '2021/06/20 18:00', 0, @TournamentId)," +
                "       ('ch', 'tk', '2021/06/20 21:00', 0, @TournamentId)," +

                "       ('ua', 'at', '2021/06/21 18:00', 0, @TournamentId)," +
                "       ('mk', 'nl', '2021/06/21 18:00', 0, @TournamentId)," +
                "       ('fi', 'be', '2021/06/21 21:00', 0, @TournamentId)," +
                "       ('ru', 'dk', '2021/06/21 21:00', 0, @TournamentId)," +

                "       ('cz', '_England', '2021/06/22 21:00', 0, @TournamentId)," +
                "       ('hr', '_Scotland', '2021/06/22 21:00', 0, @TournamentId)," +

                "       ('se', 'pl', '2021/06/23 18:00', 0, @TournamentId)," +
                "       ('sk', 'es', '2021/06/23 18:00', 0, @TournamentId)," +
                "       ('de', 'hu', '2021/06/23 21:00', 0, @TournamentId)," +
                "       ('pt', 'fr', '2021/06/23 21:00', 0, @TournamentId)" +


                ";"
                );
        }
        
        public override void Down()
        {
            Sql("DELETE FROM dbo.Tournaments WHERE Name = 'EK 2021'");
            Sql("DELETE FROM dbo.Matches WHERE DateTime > '2021/06/11'");
        }
    }
}
