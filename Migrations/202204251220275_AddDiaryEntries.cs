namespace CaloriesCount.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiaryEntries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiaryEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAdded = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        FoodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.FoodId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiaryEntries", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DiaryEntries", "FoodId", "dbo.Foods");
            DropIndex("dbo.DiaryEntries", new[] { "FoodId" });
            DropIndex("dbo.DiaryEntries", new[] { "UserId" });
            DropTable("dbo.DiaryEntries");
        }
    }
}
