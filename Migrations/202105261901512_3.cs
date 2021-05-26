namespace ProjectApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        UserProductID = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.UserProducts", t => t.UserProductID, cascadeDelete: true)
                .Index(t => t.UserProductID)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Products", "Condition", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favourites", "UserProductID", "dbo.UserProducts");
            DropForeignKey("dbo.Favourites", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Favourites", new[] { "User_Id" });
            DropIndex("dbo.Favourites", new[] { "UserProductID" });
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "Condition");
            DropTable("dbo.Favourites");
        }
    }
}
