namespace mvcEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db18 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompDrives", "IDDrive", "dbo.Drives");
            DropForeignKey("dbo.CompDrives", "IDComputer", "dbo.Computers");
            DropIndex("dbo.CompDrives", new[] { "IDComputer" });
            DropIndex("dbo.CompDrives", new[] { "IDDrive" });
            DropTable("dbo.CompDrives");
        }
    }
}
