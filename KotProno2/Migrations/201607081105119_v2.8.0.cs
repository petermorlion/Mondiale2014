namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v280 : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE TopScorers ADD IsCorrect BIT;");
        }
        
        public override void Down()
        {
            Sql("ALTER TABLE TopScorers DROP COLUMN IsCorrect;");
        }
    }
}
