namespace ProjectApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WordCategories", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.WordCategories", "Word_ID", "dbo.Words");
            DropIndex("dbo.WordCategories", new[] { "Category_ID" });
            DropIndex("dbo.WordCategories", new[] { "Word_ID" });
            RenameColumn(table: "dbo.WordCategories", name: "Category_ID", newName: "CategoryID");
            RenameColumn(table: "dbo.WordCategories", name: "Word_ID", newName: "WordID");
            AlterColumn("dbo.WordCategories", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.WordCategories", "WordID", c => c.Int(nullable: false));
            CreateIndex("dbo.WordCategories", "WordID");
            CreateIndex("dbo.WordCategories", "CategoryID");
            AddForeignKey("dbo.WordCategories", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
            AddForeignKey("dbo.WordCategories", "WordID", "dbo.Words", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WordCategories", "WordID", "dbo.Words");
            DropForeignKey("dbo.WordCategories", "CategoryID", "dbo.Categories");
            DropIndex("dbo.WordCategories", new[] { "CategoryID" });
            DropIndex("dbo.WordCategories", new[] { "WordID" });
            AlterColumn("dbo.WordCategories", "WordID", c => c.Int());
            AlterColumn("dbo.WordCategories", "CategoryID", c => c.Int());
            RenameColumn(table: "dbo.WordCategories", name: "WordID", newName: "Word_ID");
            RenameColumn(table: "dbo.WordCategories", name: "CategoryID", newName: "Category_ID");
            CreateIndex("dbo.WordCategories", "Word_ID");
            CreateIndex("dbo.WordCategories", "Category_ID");
            AddForeignKey("dbo.WordCategories", "Word_ID", "dbo.Words", "ID");
            AddForeignKey("dbo.WordCategories", "Category_ID", "dbo.Categories", "ID");
        }
    }
}
