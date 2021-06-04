namespace KotProno2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v372 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUserClaims", name: "User_Id", newName: "UserId");
            AddColumn("dbo.AspNetUsers", "Email", c => c.String());
            AddColumn("dbo.AspNetUsers", "IsConfirmed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());
            DropColumn("dbo.AspNetUsers", "IsConfirmed");
            DropColumn("dbo.AspNetUsers", "Email");
            RenameColumn(table: "dbo.AspNetUserClaims", name: "UserId", newName: "User_Id");
        }
    }
}
