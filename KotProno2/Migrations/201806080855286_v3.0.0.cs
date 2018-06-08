namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v300 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Tournaments(Name) VALUES('WK 2018');");
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'WK 2018');" +
                "INSERT INTO dbo.Matches (HomeTeamIsoCode, AwayTeamIsoCode, DateTime, Stage, IsReadOnly, Tournament_Id)" +
                "VALUES ('ru', 'sa', '2018/06/14 17:00', 0, 0, @TournamentId)," +
                
                "       ('eg', 'uy', '2018/06/15 14:00', 0, 0, @TournamentId)," +
                "       ('ma', 'ir', '2018/06/15 17:00', 0, 0, @TournamentId)," +
                "       ('pt', 'es', '2018/06/15 20:00', 0, 0, @TournamentId)," +

                "       ('fr', 'au', '2018/06/16 12:00', 0, 0, @TournamentId)," +
                "       ('ar', 'is', '2018/06/16 15:00', 0, 0, @TournamentId)," +
                "       ('pe', 'dk', '2018/06/16 18:00', 0, 0, @TournamentId)," +
                "       ('hr', 'ng', '2018/06/16 21:00', 0, 0, @TournamentId)," +
                
                "       ('cr', 'rs', '2018/06/17 14:00', 0, 0, @TournamentId)," +
                "       ('de', 'mx', '2018/06/17 17:00', 0, 0, @TournamentId)," +
                "       ('br', 'ch', '2018/06/17 20:00', 0, 0, @TournamentId)," +
                
                "       ('se', 'kr', '2018/06/18 14:00', 0, 0, @TournamentId)," +
                "       ('be', 'pa', '2018/06/18 17:00', 0, 0, @TournamentId)," +
                "       ('tn', '_England', '2018/06/18 20:00', 0, 0, @TournamentId)," +
                
                "       ('co', 'jp', '2018/06/19 14:00', 0, 0, @TournamentId)," +
                "       ('pl', 'sn', '2018/06/19 17:00', 0, 0, @TournamentId)," +
                "       ('ru', 'eg', '2018/06/19 20:00', 0, 0, @TournamentId)," +
                
                "       ('pt', 'ma', '2018/06/20 14:00', 0, 0, @TournamentId)," +
                "       ('uy', 'sa', '2018/06/20 17:00', 0, 0, @TournamentId)," +
                "       ('ir', 'es', '2018/06/20 20:00', 0, 0, @TournamentId)," +
                
                "       ('dk', 'au', '2018/06/21 14:00', 0, 0, @TournamentId)," +
                "       ('fr', 'pe', '2018/06/21 17:00', 0, 0, @TournamentId)," +
                "       ('ar', 'hr', '2018/06/21 20:00', 0, 0, @TournamentId)," +
                
                "       ('br', 'cr', '2018/06/22 14:00', 0, 0, @TournamentId)," +
                "       ('ng', 'is', '2018/06/22 17:00', 0, 0, @TournamentId)," +
                "       ('rs', 'ch', '2018/06/22 20:00', 0, 0, @TournamentId)," +
                
                "       ('be', 'tn', '2018/06/23 14:00', 0, 0, @TournamentId)," +
                "       ('kr', 'mx', '2018/06/23 17:00', 0, 0, @TournamentId)," +
                "       ('de', 'se', '2018/06/23 20:00', 0, 0, @TournamentId)," +
                
                "       ('_England', 'pa', '2018/06/24 14:00', 0, 0, @TournamentId)," +
                "       ('jp', 'sn', '2018/06/24 17:00', 0, 0, @TournamentId)," +
                "       ('pl', 'co', '2018/06/24 20:00', 0, 0, @TournamentId)," +
                
                "       ('sa', 'eg', '2018/06/25 16:00', 0, 0, @TournamentId)," +
                "       ('ur', 'ru', '2018/06/25 16:00', 0, 0, @TournamentId)," +
                "       ('ir', 'pt', '2018/06/25 20:00', 0, 0, @TournamentId)," +
                "       ('es', 'ma', '2018/06/25 20:00', 0, 0, @TournamentId)," +
                
                "       ('au', 'pe', '2018/06/26 16:00', 0, 0, @TournamentId)," +
                "       ('dk', 'fr', '2018/06/26 16:00', 0, 0, @TournamentId)," +
                "       ('ng', 'ar', '2018/06/26 20:00', 0, 0, @TournamentId)," +
                "       ('is', 'hr', '2018/06/26 20:00', 0, 0, @TournamentId)," +
                
                "       ('mx', 'se', '2018/06/27 16:00', 0, 0, @TournamentId)," +
                "       ('kr', 'de', '2018/06/27 16:00', 0, 0, @TournamentId)," +
                "       ('ch', 'cr', '2018/06/27 20:00', 0, 0, @TournamentId)," +
                "       ('rs', 'br', '2018/06/27 20:00', 0, 0, @TournamentId)," +
                
                "       ('sn', 'co', '2018/06/28 16:00', 0, 0, @TournamentId)," +
                "       ('jp', 'pl', '2018/06/28 16:00', 0, 0, @TournamentId)," +
                "       ('_England', 'be', '2018/06/28 20:00', 0, 0, @TournamentId)," +
                "       ('pa', 'tn', '2018/06/28 20:00', 0, 0, @TournamentId)" +

                ";"
                );
        }
        
        public override void Down()
        {
            Sql("DELETE FROM dbo.Tournaments WHERE Name > 'WK 2018'");
            Sql("DELETE FROM dbo.Matches WHERE DateTime > '2018/06/13'");
        }
    }
}
