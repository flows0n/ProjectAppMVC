namespace ProjectApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class image_chanegs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Image", c => c.Binary());
            AddColumn("dbo.Products", "FavouriteCount", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "VisitCount", c => c.Int(nullable: false));
            DropColumn("dbo.UserProducts", "FavouriteCount");
            DropColumn("dbo.UserProducts", "VisitCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProducts", "VisitCount", c => c.Int(nullable: false));
            AddColumn("dbo.UserProducts", "FavouriteCount", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "VisitCount");
            DropColumn("dbo.Products", "FavouriteCount");
            DropColumn("dbo.Products", "Image");
        }
    }
}
