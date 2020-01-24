namespace mvcEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Computers", "Casing_IDCasing", "dbo.Casings");
            DropIndex("dbo.Computers", new[] { "Casing_IDCasing" });
            RenameColumn(table: "dbo.Computers", name: "Casing_IDCasing", newName: "IDCasing");
            AlterColumn("dbo.Computers", "IDCasing", c => c.Int(nullable: false));
            CreateIndex("dbo.Computers", "IDCasing");
            AddForeignKey("dbo.Computers", "IDCasing", "dbo.Casings", "IDCasing", cascadeDelete: true);
            DropColumn("dbo.Computers", "IDCase");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Computers", "IDCase", c => c.Int(nullable: false));
            DropForeignKey("dbo.Computers", "IDCasing", "dbo.Casings");
            DropIndex("dbo.Computers", new[] { "IDCasing" });
            AlterColumn("dbo.Computers", "IDCasing", c => c.Int());
            RenameColumn(table: "dbo.Computers", name: "IDCasing", newName: "Casing_IDCasing");
            CreateIndex("dbo.Computers", "Casing_IDCasing");
            AddForeignKey("dbo.Computers", "Casing_IDCasing", "dbo.Casings", "IDCasing");
        }
    }
}
