namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employer", "Id", c => c.String());
            AddColumn("dbo.Freelancer", "Id", c => c.String());
            AlterColumn("dbo.Employer", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Employer", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Employer", "Organization", c => c.String(nullable: false));
            AlterColumn("dbo.Freelancer", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Freelancer", "LastName", c => c.String(nullable: false));
            CreateIndex("dbo.Employer", "StateId");
            AddForeignKey("dbo.Employer", "StateId", "dbo.State", "StateId", cascadeDelete: true);
            DropColumn("dbo.Freelancer", "CodingLanguage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Freelancer", "CodingLanguage", c => c.Int(nullable: false));
            DropForeignKey("dbo.Employer", "StateId", "dbo.State");
            DropIndex("dbo.Employer", new[] { "StateId" });
            AlterColumn("dbo.Freelancer", "LastName", c => c.String());
            AlterColumn("dbo.Freelancer", "FirstName", c => c.String());
            AlterColumn("dbo.Employer", "Organization", c => c.String());
            AlterColumn("dbo.Employer", "LastName", c => c.String());
            AlterColumn("dbo.Employer", "FirstName", c => c.String());
            DropColumn("dbo.Freelancer", "Id");
            DropColumn("dbo.Employer", "Id");
        }
    }
}
