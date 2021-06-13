namespace ProjectApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserProducts", new[] { "User_Id" });
            DropColumn("dbo.UserProducts", "UserID");
            RenameColumn(table: "dbo.UserProducts", name: "User_Id", newName: "UserID");
            AlterColumn("dbo.UserProducts", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserProducts", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserProducts", new[] { "UserID" });
            AlterColumn("dbo.UserProducts", "UserID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.UserProducts", name: "UserID", newName: "User_Id");
            AddColumn("dbo.UserProducts", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.UserProducts", "User_Id");
        }
    }
}
