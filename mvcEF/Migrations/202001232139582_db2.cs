namespace mvcEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accessories", "Description", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accessories", "Description", c => c.String(nullable: false, maxLength: 60));
        }
    }
}
