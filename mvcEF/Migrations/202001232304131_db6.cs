namespace mvcEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Computers", "Name", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Computers", "Name");
        }
    }
}
