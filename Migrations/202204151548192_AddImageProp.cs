namespace CaloriesCount.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "FoodImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foods", "FoodImage");
        }
    }
}
