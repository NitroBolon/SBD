namespace mvcEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drives", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Drives", "Memory", c => c.String(maxLength: 30));
            AlterColumn("dbo.Drives", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Coolers", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Coolers", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.GraphicsCards", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.GraphicsCards", "Memory", c => c.String(maxLength: 30));
            AlterColumn("dbo.GraphicsCards", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Motherboards", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Motherboards", "Socket", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Motherboards", "Standard", c => c.String(maxLength: 30));
            AlterColumn("dbo.Motherboards", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.PowerSupplies", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.PowerSupplies", "Power", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.PowerSupplies", "Standard", c => c.String(maxLength: 30));
            AlterColumn("dbo.PowerSupplies", "Certificate", c => c.String(maxLength: 30));
            AlterColumn("dbo.PowerSupplies", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Processors", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Processors", "Socket", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Processors", "Architecture", c => c.String(maxLength: 30));
            AlterColumn("dbo.Processors", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.RAMs", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.RAMs", "Memory", c => c.String(maxLength: 30));
            AlterColumn("dbo.RAMs", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Deliveries", "Name", c => c.String(maxLength: 60));
            AlterColumn("dbo.Peripherals", "Name", c => c.String(maxLength: 60));
            AlterColumn("dbo.Peripherals", "Description", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Peripherals", "Description", c => c.String());
            AlterColumn("dbo.Peripherals", "Name", c => c.String());
            AlterColumn("dbo.Deliveries", "Name", c => c.String());
            AlterColumn("dbo.RAMs", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.RAMs", "Memory", c => c.String());
            AlterColumn("dbo.RAMs", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Processors", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Processors", "Architecture", c => c.String());
            AlterColumn("dbo.Processors", "Socket", c => c.String(nullable: false));
            AlterColumn("dbo.Processors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.PowerSupplies", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.PowerSupplies", "Certificate", c => c.String());
            AlterColumn("dbo.PowerSupplies", "Standard", c => c.String());
            AlterColumn("dbo.PowerSupplies", "Power", c => c.String(nullable: false));
            AlterColumn("dbo.PowerSupplies", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Motherboards", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Motherboards", "Standard", c => c.String());
            AlterColumn("dbo.Motherboards", "Socket", c => c.String(nullable: false));
            AlterColumn("dbo.Motherboards", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.GraphicsCards", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.GraphicsCards", "Memory", c => c.String());
            AlterColumn("dbo.GraphicsCards", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Coolers", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Coolers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Drives", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Drives", "Memory", c => c.String());
            AlterColumn("dbo.Drives", "Name", c => c.String(nullable: false));
        }
    }
}
