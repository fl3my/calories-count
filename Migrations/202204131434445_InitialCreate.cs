namespace CaloriesCount.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImageURL = c.String(),
                        Calories = c.Int(nullable: false),
                        Fat = c.Double(nullable: false),
                        Protein = c.Double(nullable: false),
                        Carbohydrates = c.Double(nullable: false),
                        fibre = c.Double(nullable: false),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Foods", new[] { "CategoryId" });
            DropTable("dbo.Foods");
            DropTable("dbo.Categories");
        }
    }
}
