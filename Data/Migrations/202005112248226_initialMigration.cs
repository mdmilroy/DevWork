namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "State", c => c.String());
            AddColumn("dbo.ApplicationUser", "Organization", c => c.String());
            AddColumn("dbo.ApplicationUser", "CodingLanguage", c => c.String());
            AlterColumn("dbo.CodingLanguage", "LanguageName", c => c.String());
            AlterColumn("dbo.Employer", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Employer", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Employer", "Organization", c => c.String(nullable: false));
            AlterColumn("dbo.Employer", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.State", "StateName", c => c.String());
            AlterColumn("dbo.Freelancer", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Freelancer", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Freelancer", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Freelancer", "Email", c => c.String());
            AlterColumn("dbo.Freelancer", "LastName", c => c.String());
            AlterColumn("dbo.Freelancer", "FirstName", c => c.String());
            AlterColumn("dbo.State", "StateName", c => c.Int(nullable: false));
            AlterColumn("dbo.Employer", "Email", c => c.String());
            AlterColumn("dbo.Employer", "Organization", c => c.String());
            AlterColumn("dbo.Employer", "LastName", c => c.String());
            AlterColumn("dbo.Employer", "FirstName", c => c.String());
            AlterColumn("dbo.CodingLanguage", "LanguageName", c => c.Int(nullable: false));
            DropColumn("dbo.ApplicationUser", "CodingLanguage");
            DropColumn("dbo.ApplicationUser", "Organization");
            DropColumn("dbo.ApplicationUser", "State");
        }
    }
}
