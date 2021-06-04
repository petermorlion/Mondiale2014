namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v376 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.Matches SET HomeTeamIsoCode = '_England' WHERE HomeTeamIsoCode = '_Englang'");
            
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'Euro 2020');" +
                "UPDATE dbo.Matches SET AwayTeamIsoCode = 'tr' WHERE AwayTeamIsoCode = 'tk' AND Tournament_Id = @TournamentId" +

                ";"
                );
        }
        
        public override void Down()
        {
        }
    }
}
