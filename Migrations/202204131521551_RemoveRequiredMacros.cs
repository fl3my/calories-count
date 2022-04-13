namespace CaloriesCount.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredMacros : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "Fat", c => c.Double());
            AlterColumn("dbo.Foods", "Protein", c => c.Double());
            AlterColumn("dbo.Foods", "Carbohydrates", c => c.Double());
            AlterColumn("dbo.Foods", "fibre", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "fibre", c => c.Double(nullable: false));
            AlterColumn("dbo.Foods", "Carbohydrates", c => c.Double(nullable: false));
            AlterColumn("dbo.Foods", "Protein", c => c.Double(nullable: false));
            AlterColumn("dbo.Foods", "Fat", c => c.Double(nullable: false));
        }
    }
}
