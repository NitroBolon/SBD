namespace mvcEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db16 : DbMigration
    {
        public override void Up()
        {
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
            DropForeignKey("dbo.DriveComputers", "Computer_IDComputer", "dbo.Computers");
            DropForeignKey("dbo.DriveComputers", "Drive_IDDrive", "dbo.Drives");
            DropIndex("dbo.DriveComputers", new[] { "Computer_IDComputer" });
            DropIndex("dbo.DriveComputers", new[] { "Drive_IDDrive" });
            DropTable("dbo.DriveComputers");
        }
    }
}
