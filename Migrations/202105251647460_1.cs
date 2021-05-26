namespace ProjectApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        AddDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        FavouriteCount = c.Int(nullable: false),
                        VisitCount = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.ProductID)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProducts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserProducts", "ProductID", "dbo.Products");
            DropIndex("dbo.UserProducts", new[] { "User_Id" });
            DropIndex("dbo.UserProducts", new[] { "ProductID" });
            DropTable("dbo.UserProducts");
        }
    }
}
