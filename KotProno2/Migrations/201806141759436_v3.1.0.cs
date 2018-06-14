namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v310 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Matches", "Date");
            DropColumn("dbo.Matches", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matches", "Time", c => c.String());
            AddColumn("dbo.Matches", "Date", c => c.String());
        }
    }
}
