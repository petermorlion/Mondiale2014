namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v371 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.Matches SET HomeTeamIsoCode = 'England' WHERE HomeTeamIsoCode = 'Englang'");
            Sql("UPDATE dbo.Tournaments SET Name = 'Euro 2020' WHERE Name = 'EK 2021';");
        }
        
        public override void Down()
        {
        }
    }
}
