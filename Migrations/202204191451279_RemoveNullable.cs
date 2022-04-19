namespace CaloriesCount.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "Fat", c => c.Double(nullable: false));
            AlterColumn("dbo.Foods", "Protein", c => c.Double(nullable: false));
            AlterColumn("dbo.Foods", "Carbohydrates", c => c.Double(nullable: false));
            AlterColumn("dbo.Foods", "Fibre", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "Fibre", c => c.Double());
            AlterColumn("dbo.Foods", "Carbohydrates", c => c.Double());
            AlterColumn("dbo.Foods", "Protein", c => c.Double());
            AlterColumn("dbo.Foods", "Fat", c => c.Double());
        }
    }
}
