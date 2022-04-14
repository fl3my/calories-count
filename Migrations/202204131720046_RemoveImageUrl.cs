namespace CaloriesCount.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveImageUrl : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Foods", "ImageURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "ImageURL", c => c.String());
        }
    }
}
