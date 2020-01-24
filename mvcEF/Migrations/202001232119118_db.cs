namespace mvcEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accessories", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Accessories", "Description", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accessories", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Accessories", "Name", c => c.String(nullable: false));
        }
    }
}
