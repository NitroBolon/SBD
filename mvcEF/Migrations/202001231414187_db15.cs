namespace mvcEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db15 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CompDrivesContexts", "IDComputer", "dbo.Computers");
            DropForeignKey("dbo.CompDrivesContexts", "IDDrive", "dbo.Drives");
            DropIndex("dbo.CompDrivesContexts", new[] { "IDDrive" });
            DropIndex("dbo.CompDrivesContexts", new[] { "IDComputer" });
            DropTable("dbo.CompDrivesContexts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CompDrivesContexts",
                c => new
                    {
                        IDDrive = c.Int(nullable: false),
                        IDComputer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IDDrive, t.IDComputer });
            
            CreateIndex("dbo.CompDrivesContexts", "IDComputer");
            CreateIndex("dbo.CompDrivesContexts", "IDDrive");
            AddForeignKey("dbo.CompDrivesContexts", "IDDrive", "dbo.Drives", "IDDrive", cascadeDelete: true);
            AddForeignKey("dbo.CompDrivesContexts", "IDComputer", "dbo.Computers", "IDComputer", cascadeDelete: true);
        }
    }
}
