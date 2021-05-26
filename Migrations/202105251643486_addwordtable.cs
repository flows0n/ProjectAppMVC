namespace ProjectApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addwordtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WordCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Category_ID = c.Int(),
                        Word_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .ForeignKey("dbo.Words", t => t.Word_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.Word_ID);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WordCategories", "Word_ID", "dbo.Words");
            DropForeignKey("dbo.WordCategories", "Category_ID", "dbo.Categories");
            DropIndex("dbo.WordCategories", new[] { "Word_ID" });
            DropIndex("dbo.WordCategories", new[] { "Category_ID" });
            DropTable("dbo.Words");
            DropTable("dbo.WordCategories");
        }
    }
}
