namespace RetailStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryParendID_as_nullable_type : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "ParentCategoryID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "ParentCategoryID", c => c.Int(nullable: false));
        }
    }
}
