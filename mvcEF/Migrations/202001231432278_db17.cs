namespace mvcEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db17 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DriveComputers", "Drive_IDDrive", "dbo.Drives");
            DropForeignKey("dbo.DriveComputers", "Computer_IDComputer", "dbo.Computers");
            DropIndex("dbo.DriveComputers", new[] { "Drive_IDDrive" });
            DropIndex("dbo.DriveComputers", new[] { "Computer_IDComputer" });
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
            
            CreateIndex("dbo.DriveComputers", "Computer_IDComputer");
            CreateIndex("dbo.DriveComputers", "Drive_IDDrive");
            AddForeignKey("dbo.DriveComputers", "Computer_IDComputer", "dbo.Computers", "IDComputer", cascadeDelete: true);
            AddForeignKey("dbo.DriveComputers", "Drive_IDDrive", "dbo.Drives", "IDDrive", cascadeDelete: true);
        }
    }
}
