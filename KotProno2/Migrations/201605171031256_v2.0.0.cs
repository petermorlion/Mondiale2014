namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v200 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Matches", "Tournament_Id", c => c.Int());
            CreateIndex("dbo.Matches", "Tournament_Id");
            AddForeignKey("dbo.Matches", "Tournament_Id", "dbo.Tournaments", "Id");

            Sql("INSERT INTO dbo.Tournaments(Name) VALUES('WK 2014'), ('EK 2016');");
            Sql("UPDATE dbo.Matches SET Tournament_Id = (SELECT Id FROM dbo.Tournaments WHERE Name = 'WK 2014');");
            Sql("DECLARE @TournamentId INT;" +
                "SET @TournamentId = (SELECT Id FROM dbo.Tournaments WHERE Name = 'EK 2016');" +
                "INSERT INTO dbo.Matches (HomeTeamIsoCode, AwayTeamIsoCode, DateTime, Stage, IsReadOnly, Tournament_Id)" +
                "VALUES ('fr', 'ro', '2016/06/10 21:00', 0, 0, @TournamentId)," +
                "       ('gb', 'ru', '2016/06/11 21:00', 0, 0, @TournamentId)," +
                "       ('_Wales', 'sk', '2016/06/11 18:00', 0, 0, @TournamentId)," +
                "       ('al', 'ch', '2016/06/11 18:00', 0, 0, @TournamentId);"
                );
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "Tournament_Id", "dbo.Tournaments");
            DropIndex("dbo.Matches", new[] { "Tournament_Id" });
            DropColumn("dbo.Matches", "Tournament_Id");
            DropTable("dbo.Tournaments");

            Sql("DELETE FROM dbo.Matches WHERE DateTime > '2016/01/01'");
        }
    }
}
