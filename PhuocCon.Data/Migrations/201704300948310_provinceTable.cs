namespace PhuocCon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class provinceTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CountryDetails", "CountryID", "dbo.Countrys");
            DropIndex("dbo.CountryDetails", new[] { "CountryID" });
            CreateTable(
                "dbo.District",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Type = c.String(),
                        ProvinceID = c.Int(nullable: false),
                        SortOrder = c.Int(),
                        Status = c.Boolean(),
                        IsDelete = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Province", t => t.ProvinceID, cascadeDelete: true)
                .Index(t => t.ProvinceID);
            
            CreateTable(
                "dbo.Province",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        TelePhoneCode = c.String(),
                        CountryID = c.Int(nullable: false),
                        CountryCode = c.String(),
                        SortOrder = c.Int(),
                        Status = c.Boolean(),
                        IsDelete = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Countrys", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Ward",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Type = c.String(),
                        DistrictID = c.Int(nullable: false),
                        SortOrder = c.Int(),
                        Status = c.Boolean(),
                        IsDelete = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.District", t => t.DistrictID, cascadeDelete: true)
                .Index(t => t.DistrictID);
            
            AddColumn("dbo.Countrys", "Name", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.Countrys", "Slug", c => c.String());
            AddColumn("dbo.Countrys", "Capital", c => c.String());
            AddColumn("dbo.Countrys", "Sovereignty", c => c.String());
            AddColumn("dbo.Countrys", "CurrencyName", c => c.String());
            AddColumn("dbo.Countrys", "FormalName", c => c.String());
            AddColumn("dbo.Countrys", "CountryType", c => c.String());
            AddColumn("dbo.Countrys", "CountrySubType", c => c.String());
            AddColumn("dbo.Countrys", "CountryNumber", c => c.String());
            AddColumn("dbo.Countrys", "TelephoneCode", c => c.String());
            AddColumn("dbo.Countrys", "InternetCountryCode", c => c.String());
            AddColumn("dbo.Countrys", "SortOrder", c => c.Int());
            AddColumn("dbo.Countrys", "Status", c => c.Boolean());
            AddColumn("dbo.Countrys", "Flags", c => c.Boolean());
            AddColumn("dbo.Countrys", "IsDelete", c => c.Boolean());
            DropColumn("dbo.Countrys", "Country_Name");
            DropTable("dbo.CountryDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CountryDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CountryID = c.Int(nullable: false),
                        ContryDetail_Name = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Countrys", "Country_Name", c => c.String(nullable: false, maxLength: 256));
            DropForeignKey("dbo.Ward", "DistrictID", "dbo.District");
            DropForeignKey("dbo.District", "ProvinceID", "dbo.Province");
            DropForeignKey("dbo.Province", "CountryID", "dbo.Countrys");
            DropIndex("dbo.Ward", new[] { "DistrictID" });
            DropIndex("dbo.Province", new[] { "CountryID" });
            DropIndex("dbo.District", new[] { "ProvinceID" });
            DropColumn("dbo.Countrys", "IsDelete");
            DropColumn("dbo.Countrys", "Flags");
            DropColumn("dbo.Countrys", "Status");
            DropColumn("dbo.Countrys", "SortOrder");
            DropColumn("dbo.Countrys", "InternetCountryCode");
            DropColumn("dbo.Countrys", "TelephoneCode");
            DropColumn("dbo.Countrys", "CountryNumber");
            DropColumn("dbo.Countrys", "CountrySubType");
            DropColumn("dbo.Countrys", "CountryType");
            DropColumn("dbo.Countrys", "FormalName");
            DropColumn("dbo.Countrys", "CurrencyName");
            DropColumn("dbo.Countrys", "Sovereignty");
            DropColumn("dbo.Countrys", "Capital");
            DropColumn("dbo.Countrys", "Slug");
            DropColumn("dbo.Countrys", "Name");
            DropTable("dbo.Ward");
            DropTable("dbo.Province");
            DropTable("dbo.District");
            CreateIndex("dbo.CountryDetails", "CountryID");
            AddForeignKey("dbo.CountryDetails", "CountryID", "dbo.Countrys", "ID", cascadeDelete: true);
        }
    }
}
