namespace CaloriesCount.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiaryEntries", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DiaryEntries", "TotalCalories", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Foods", "Calories", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "Calories", c => c.Int(nullable: false));
            DropColumn("dbo.DiaryEntries", "TotalCalories");
            DropColumn("dbo.DiaryEntries", "Quantity");
        }
    }
}
