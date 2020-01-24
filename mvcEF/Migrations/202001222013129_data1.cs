namespace mvcEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        IDAccessory = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDAccessory);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        IDCart = c.Int(nullable: false, identity: true),
                        IDComputer = c.Int(nullable: false),
                        Accessory = c.Int(nullable: false),
                        Peripheral = c.Int(nullable: false),
                        accessories_IDAccessory = c.Int(),
                        peripherals_IDPeripheral = c.Int(),
                    })
                .PrimaryKey(t => t.IDCart)
                .ForeignKey("dbo.Accessories", t => t.accessories_IDAccessory)
                .ForeignKey("dbo.Computers", t => t.IDComputer, cascadeDelete: true)
                .ForeignKey("dbo.Peripherals", t => t.peripherals_IDPeripheral)
                .Index(t => t.IDComputer)
                .Index(t => t.accessories_IDAccessory)
                .Index(t => t.peripherals_IDPeripheral);
            
            CreateTable(
                "dbo.Computers",
                c => new
                    {
                        IDComputer = c.Int(nullable: false, identity: true),
                        IDCase = c.Int(nullable: false),
                        IDPowerSupply = c.Int(nullable: false),
                        IDMotherboard = c.Int(nullable: false),
                        IDProcessor = c.Int(nullable: false),
                        IDGraphicsCard = c.Int(nullable: false),
                        IDCooler = c.Int(nullable: false),
                        IDRAM = c.Int(nullable: false),
                        Casing_IDCasing = c.Int(),
                    })
                .PrimaryKey(t => t.IDComputer)
                .ForeignKey("dbo.Casings", t => t.Casing_IDCasing)
                .ForeignKey("dbo.Coolers", t => t.IDCooler, cascadeDelete: true)
                .ForeignKey("dbo.GraphicsCards", t => t.IDGraphicsCard, cascadeDelete: true)
                .ForeignKey("dbo.Motherboards", t => t.IDMotherboard, cascadeDelete: true)
                .ForeignKey("dbo.PowerSupplies", t => t.IDPowerSupply, cascadeDelete: true)
                .ForeignKey("dbo.Processors", t => t.IDProcessor, cascadeDelete: true)
                .ForeignKey("dbo.RAMs", t => t.IDRAM, cascadeDelete: true)
                .Index(t => t.IDPowerSupply)
                .Index(t => t.IDMotherboard)
                .Index(t => t.IDProcessor)
                .Index(t => t.IDGraphicsCard)
                .Index(t => t.IDCooler)
                .Index(t => t.IDRAM)
                .Index(t => t.Casing_IDCasing);
            
            CreateTable(
                "dbo.Casings",
                c => new
                    {
                        IDCasing = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Fans = c.Int(nullable: false),
                        Standard = c.String(),
                        Description = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDCasing);
            
            CreateTable(
                "dbo.Coolers",
                c => new
                    {
                        IDCooler = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        hasFan = c.Boolean(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDCooler);
            
            CreateTable(
                "dbo.Drives",
                c => new
                    {
                        IDDrive = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Memory = c.String(),
                        Description = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDDrive);
            
            CreateTable(
                "dbo.GraphicsCards",
                c => new
                    {
                        IDGraphicsCard = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Memory = c.String(),
                        Description = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDGraphicsCard);
            
            CreateTable(
                "dbo.Motherboards",
                c => new
                    {
                        IDMotherboard = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Socket = c.String(nullable: false),
                        Standard = c.String(),
                        Description = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDMotherboard);
            
            CreateTable(
                "dbo.PowerSupplies",
                c => new
                    {
                        IDPowerSupply = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Power = c.String(nullable: false),
                        Standard = c.String(),
                        Certificate = c.String(),
                        Description = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDPowerSupply);
            
            CreateTable(
                "dbo.Processors",
                c => new
                    {
                        IDProcessor = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Socket = c.String(nullable: false),
                        Architecture = c.String(),
                        Description = c.String(nullable: false),
                        isLocked = c.Boolean(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDProcessor);
            
            CreateTable(
                "dbo.RAMs",
                c => new
                    {
                        IDRAM = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Memory = c.String(),
                        Description = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDRAM);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        IDOrder = c.Int(nullable: false, identity: true),
                        IDCart = c.Int(nullable: false),
                        orderDate = c.DateTime(nullable: false),
                        IDDelivery = c.Int(nullable: false),
                        IDClient = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDOrder)
                .ForeignKey("dbo.Carts", t => t.IDCart, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.IDClient, cascadeDelete: true)
                .ForeignKey("dbo.Deliveries", t => t.IDDelivery, cascadeDelete: true)
                .Index(t => t.IDCart)
                .Index(t => t.IDDelivery)
                .Index(t => t.IDClient);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IDClient = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IDContact = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDClient)
                .ForeignKey("dbo.Contacts", t => t.IDContact, cascadeDelete: true)
                .Index(t => t.IDContact);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        IDContact = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IDContact);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        IDDelivery = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.IDDelivery);
            
            CreateTable(
                "dbo.Peripherals",
                c => new
                    {
                        IDPeripheral = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDPeripheral);
            
            CreateTable(
                "dbo.DriveComputers",
                c => new
                    {
                        Drive_IDDrive = c.Int(nullable: false),
                        Computer_IDComputer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Drive_IDDrive, t.Computer_IDComputer })
                .ForeignKey("dbo.Drives", t => t.Drive_IDDrive, cascadeDelete: true)
                .ForeignKey("dbo.Computers", t => t.Computer_IDComputer, cascadeDelete: true)
                .Index(t => t.Drive_IDDrive)
                .Index(t => t.Computer_IDComputer);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "peripherals_IDPeripheral", "dbo.Peripherals");
            DropForeignKey("dbo.Orders", "IDDelivery", "dbo.Deliveries");
            DropForeignKey("dbo.Orders", "IDClient", "dbo.Clients");
            DropForeignKey("dbo.Clients", "IDContact", "dbo.Contacts");
            DropForeignKey("dbo.Orders", "IDCart", "dbo.Carts");
            DropForeignKey("dbo.Computers", "IDRAM", "dbo.RAMs");
            DropForeignKey("dbo.Computers", "IDProcessor", "dbo.Processors");
            DropForeignKey("dbo.Computers", "IDPowerSupply", "dbo.PowerSupplies");
            DropForeignKey("dbo.Computers", "IDMotherboard", "dbo.Motherboards");
            DropForeignKey("dbo.Computers", "IDGraphicsCard", "dbo.GraphicsCards");
            DropForeignKey("dbo.DriveComputers", "Computer_IDComputer", "dbo.Computers");
            DropForeignKey("dbo.DriveComputers", "Drive_IDDrive", "dbo.Drives");
            DropForeignKey("dbo.Computers", "IDCooler", "dbo.Coolers");
            DropForeignKey("dbo.Computers", "Casing_IDCasing", "dbo.Casings");
            DropForeignKey("dbo.Carts", "IDComputer", "dbo.Computers");
            DropForeignKey("dbo.Carts", "accessories_IDAccessory", "dbo.Accessories");
            DropIndex("dbo.DriveComputers", new[] { "Computer_IDComputer" });
            DropIndex("dbo.DriveComputers", new[] { "Drive_IDDrive" });
            DropIndex("dbo.Clients", new[] { "IDContact" });
            DropIndex("dbo.Orders", new[] { "IDClient" });
            DropIndex("dbo.Orders", new[] { "IDDelivery" });
            DropIndex("dbo.Orders", new[] { "IDCart" });
            DropIndex("dbo.Computers", new[] { "Casing_IDCasing" });
            DropIndex("dbo.Computers", new[] { "IDRAM" });
            DropIndex("dbo.Computers", new[] { "IDCooler" });
            DropIndex("dbo.Computers", new[] { "IDGraphicsCard" });
            DropIndex("dbo.Computers", new[] { "IDProcessor" });
            DropIndex("dbo.Computers", new[] { "IDMotherboard" });
            DropIndex("dbo.Computers", new[] { "IDPowerSupply" });
            DropIndex("dbo.Carts", new[] { "peripherals_IDPeripheral" });
            DropIndex("dbo.Carts", new[] { "accessories_IDAccessory" });
            DropIndex("dbo.Carts", new[] { "IDComputer" });
            DropTable("dbo.DriveComputers");
            DropTable("dbo.Peripherals");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Contacts");
            DropTable("dbo.Clients");
            DropTable("dbo.Orders");
            DropTable("dbo.RAMs");
            DropTable("dbo.Processors");
            DropTable("dbo.PowerSupplies");
            DropTable("dbo.Motherboards");
            DropTable("dbo.GraphicsCards");
            DropTable("dbo.Drives");
            DropTable("dbo.Coolers");
            DropTable("dbo.Casings");
            DropTable("dbo.Computers");
            DropTable("dbo.Carts");
            DropTable("dbo.Accessories");
        }
    }
}
