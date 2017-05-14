namespace PhuocCon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Providertable : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Providers",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 256),
            //            Image = c.String(maxLength: 256),
            //            Status = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //AddColumn("dbo.Products", "ProviderID", c => c.Int(nullable: false));
            //CreateIndex("dbo.Products", "ProviderID");
            //AddForeignKey("dbo.Products", "ProviderID", "dbo.Providers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Products", "ProviderID", "dbo.Providers");
            //DropIndex("dbo.Products", new[] { "ProviderID" });
            //DropColumn("dbo.Products", "ProviderID");
            //DropTable("dbo.Providers");
        }
    }
}
