namespace mvcEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DriveComputers", "Drive_IDDrive", "dbo.Drives");
            DropForeignKey("dbo.DriveComputers", "Computer_IDComputer", "dbo.Computers");
            DropForeignKey("dbo.Computers", "Casing_IDCasing", "dbo.Casings");
            DropIndex("dbo.Computers", new[] { "Casing_IDCasing" });
            DropIndex("dbo.DriveComputers", new[] { "Drive_IDDrive" });
            DropIndex("dbo.DriveComputers", new[] { "Computer_IDComputer" });
            RenameColumn(table: "dbo.Computers", name: "Casing_IDCasing", newName: "IDCasing");
            CreateTable(
                "dbo.CompDrives",
                c => new
                    {
                        IDDrive = c.Int(nullable: false),
                        IDComputer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IDDrive, t.IDComputer })
                .ForeignKey("dbo.Computers", t => t.IDComputer, cascadeDelete: true)
                .ForeignKey("dbo.Drives", t => t.IDDrive, cascadeDelete: true)
                .Index(t => t.IDDrive)
                .Index(t => t.IDComputer);
            
            AddColumn("dbo.Computers", "Drive_IDDrive", c => c.Int());
            AlterColumn("dbo.Accessories", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Accessories", "Description", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Computers", "IDCasing", c => c.Int(nullable: false));
            CreateIndex("dbo.Computers", "IDCasing");
            CreateIndex("dbo.Computers", "Drive_IDDrive");
            AddForeignKey("dbo.Computers", "Drive_IDDrive", "dbo.Drives", "IDDrive");
            AddForeignKey("dbo.Computers", "IDCasing", "dbo.Casings", "IDCasing", cascadeDelete: true);
            DropColumn("dbo.Computers", "IDCase");
            DropTable("dbo.DriveComputers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DriveComputers",
                c => new
                    {
                        Drive_IDDrive = c.Int(nullable: false),
                        Computer_IDComputer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Drive_IDDrive, t.Computer_IDComputer });
            
            AddColumn("dbo.Computers", "IDCase", c => c.Int(nullable: false));
            DropForeignKey("dbo.Computers", "IDCasing", "dbo.Casings");
            DropForeignKey("dbo.CompDrives", "IDDrive", "dbo.Drives");
            DropForeignKey("dbo.Computers", "Drive_IDDrive", "dbo.Drives");
            DropForeignKey("dbo.CompDrives", "IDComputer", "dbo.Computers");
            DropIndex("dbo.CompDrives", new[] { "IDComputer" });
            DropIndex("dbo.CompDrives", new[] { "IDDrive" });
            DropIndex("dbo.Computers", new[] { "Drive_IDDrive" });
            DropIndex("dbo.Computers", new[] { "IDCasing" });
            AlterColumn("dbo.Computers", "IDCasing", c => c.Int());
            AlterColumn("dbo.Accessories", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Accessories", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Computers", "Drive_IDDrive");
            DropTable("dbo.CompDrives");
            RenameColumn(table: "dbo.Computers", name: "IDCasing", newName: "Casing_IDCasing");
            CreateIndex("dbo.DriveComputers", "Computer_IDComputer");
            CreateIndex("dbo.DriveComputers", "Drive_IDDrive");
            CreateIndex("dbo.Computers", "Casing_IDCasing");
            AddForeignKey("dbo.Computers", "Casing_IDCasing", "dbo.Casings", "IDCasing");
            AddForeignKey("dbo.DriveComputers", "Computer_IDComputer", "dbo.Computers", "IDComputer", cascadeDelete: true);
            AddForeignKey("dbo.DriveComputers", "Drive_IDDrive", "dbo.Drives", "IDDrive", cascadeDelete: true);
        }
    }
}
