namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v270 : DbMigration
    {
        public override void Up()
        {
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'EK 2016');" +
                "INSERT INTO dbo.Matches (HomeTeamIsoCode, AwayTeamIsoCode, DateTime, Stage, IsReadOnly, Tournament_Id)" +
                "VALUES ('pt', 'fr', '2016/07/10 21:00', 4, 0, @TournamentId);"
                );
        }

        public override void Down()
        {
            Sql("DELETE FROM dbo.Matches WHERE DateTime > '2016/07/10'");
        }
    }
}
