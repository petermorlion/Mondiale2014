namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v130 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "Stage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "Stage");
        }
    }
}
