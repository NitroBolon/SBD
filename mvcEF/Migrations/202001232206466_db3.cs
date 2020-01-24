namespace mvcEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Casings", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Casings", "Standard", c => c.String(maxLength: 30));
            AlterColumn("dbo.Casings", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Clients", "Name", c => c.String(maxLength: 120));
            AlterColumn("dbo.Contacts", "Street", c => c.String(maxLength: 60));
            AlterColumn("dbo.Contacts", "City", c => c.String(maxLength: 60));
            AlterColumn("dbo.Contacts", "PostalCode", c => c.String(maxLength: 10));
            AlterColumn("dbo.Contacts", "Email", c => c.String(maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Email", c => c.String());
            AlterColumn("dbo.Contacts", "PostalCode", c => c.String());
            AlterColumn("dbo.Contacts", "City", c => c.String());
            AlterColumn("dbo.Contacts", "Street", c => c.String());
            AlterColumn("dbo.Clients", "Name", c => c.String());
            AlterColumn("dbo.Casings", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Casings", "Standard", c => c.String());
            AlterColumn("dbo.Casings", "Name", c => c.String(nullable: false));
        }
    }
}
