namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v140 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "PenaltyWinner", c => c.Int());
        }
        
        public override void Down() 
        {
            DropColumn("dbo.Matches", "PenaltyWinner");
        }
    }
}
