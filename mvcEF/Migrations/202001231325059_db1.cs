namespace mvcEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "accessories_IDAccessory", "dbo.Accessories");
            DropForeignKey("dbo.Carts", "peripherals_IDPeripheral", "dbo.Peripherals");
            DropIndex("dbo.Carts", new[] { "accessories_IDAccessory" });
            DropIndex("dbo.Carts", new[] { "peripherals_IDPeripheral" });
            RenameColumn(table: "dbo.Carts", name: "accessories_IDAccessory", newName: "IDAccessory");
            RenameColumn(table: "dbo.Carts", name: "peripherals_IDPeripheral", newName: "IDPeripheral");
            AlterColumn("dbo.Carts", "IDAccessory", c => c.Int(nullable: false));
            AlterColumn("dbo.Carts", "IDPeripheral", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "IDAccessory");
            CreateIndex("dbo.Carts", "IDPeripheral");
            AddForeignKey("dbo.Carts", "IDAccessory", "dbo.Accessories", "IDAccessory", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "IDPeripheral", "dbo.Peripherals", "IDPeripheral", cascadeDelete: true);
            DropColumn("dbo.Carts", "Accessory");
            DropColumn("dbo.Carts", "Peripheral");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "Peripheral", c => c.Int(nullable: false));
            AddColumn("dbo.Carts", "Accessory", c => c.Int(nullable: false));
            DropForeignKey("dbo.Carts", "IDPeripheral", "dbo.Peripherals");
            DropForeignKey("dbo.Carts", "IDAccessory", "dbo.Accessories");
            DropIndex("dbo.Carts", new[] { "IDPeripheral" });
            DropIndex("dbo.Carts", new[] { "IDAccessory" });
            AlterColumn("dbo.Carts", "IDPeripheral", c => c.Int());
            AlterColumn("dbo.Carts", "IDAccessory", c => c.Int());
            RenameColumn(table: "dbo.Carts", name: "IDPeripheral", newName: "peripherals_IDPeripheral");
            RenameColumn(table: "dbo.Carts", name: "IDAccessory", newName: "accessories_IDAccessory");
            CreateIndex("dbo.Carts", "peripherals_IDPeripheral");
            CreateIndex("dbo.Carts", "accessories_IDAccessory");
            AddForeignKey("dbo.Carts", "peripherals_IDPeripheral", "dbo.Peripherals", "IDPeripheral");
            AddForeignKey("dbo.Carts", "accessories_IDAccessory", "dbo.Accessories", "IDAccessory");
        }
    }
}
