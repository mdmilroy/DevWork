namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileServiceAndController : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employer", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Freelancer", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Freelancer", "LanguageId", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "State", c => c.String());
            AddColumn("dbo.ApplicationUser", "Organization", c => c.String());
            AddColumn("dbo.ApplicationUser", "CodingLanguage", c => c.String());
            CreateIndex("dbo.Freelancer", "LanguageId");
            AddForeignKey("dbo.Freelancer", "LanguageId", "dbo.CodingLanguage", "LanguageId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Freelancer", "LanguageId", "dbo.CodingLanguage");
            DropIndex("dbo.Freelancer", new[] { "LanguageId" });
            DropColumn("dbo.ApplicationUser", "CodingLanguage");
            DropColumn("dbo.ApplicationUser", "Organization");
            DropColumn("dbo.ApplicationUser", "State");
            DropColumn("dbo.Freelancer", "LanguageId");
            DropColumn("dbo.Freelancer", "Email");
            DropColumn("dbo.Employer", "Email");
        }
    }
}
