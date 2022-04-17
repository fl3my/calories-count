namespace CaloriesCount.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "ImageFileName", c => c.String());
            DropColumn("dbo.Foods", "FoodImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "FoodImage", c => c.String());
            DropColumn("dbo.Foods", "ImageFileName");
        }
    }
}
