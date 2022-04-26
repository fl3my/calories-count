namespace CaloriesCount.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiaryEntries", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.DiaryEntries", "TotalCalories", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DiaryEntries", "TotalCalories");
            DropColumn("dbo.DiaryEntries", "Quantity");
        }
    }
}
