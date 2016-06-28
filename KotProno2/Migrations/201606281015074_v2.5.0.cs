namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v250 : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'EK 2016');" +
                "INSERT INTO dbo.Matches (HomeTeamIsoCode, AwayTeamIsoCode, DateTime, Stage, IsReadOnly, Tournament_Id)" +
                "VALUES ('pl', 'pt', '2016/06/30 21:00', 2, 0, @TournamentId)," +
                "       ('_Wales', 'be', '2016/07/01 21:00', 2, 0, @TournamentId)," +
                "       ('de', 'it', '2016/07/02 21:00', 2, 0, @TournamentId)," +
                "       ('fr', 'is', '2016/07/03 21:00', 2, 0, @TournamentId)" +
                ";"
                );
        }
        
        public override void Down()
        {
            Sql("DELETE FROM dbo.Matches WHERE DateTime > '2016/06/30'");
        }
    }
}
