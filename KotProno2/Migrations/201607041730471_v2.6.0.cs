namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v260 : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'EK 2016');" +
                "INSERT INTO dbo.Matches (HomeTeamIsoCode, AwayTeamIsoCode, DateTime, Stage, IsReadOnly, Tournament_Id)" +
                "VALUES ('pt', '_Wales', '2016/07/06 21:00', 3, 0, @TournamentId)," +
                "       ('de', 'fr', '2016/07/07 21:00', 3, 0, @TournamentId)" +
                ";"
                );
        }
        
        public override void Down()
        {
            Sql("DELETE FROM dbo.Matches WHERE DateTime > '2016/07/06'");
        }
    }
}
