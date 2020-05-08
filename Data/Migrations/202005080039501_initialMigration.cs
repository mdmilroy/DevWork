namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employer", "StateId", c => c.Int(nullable: false));
            AddColumn("dbo.Freelancer", "StateId", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "UserRole", c => c.String());
            CreateIndex("dbo.Employer", "StateId");
            CreateIndex("dbo.Freelancer", "StateId");
            AddForeignKey("dbo.Employer", "StateId", "dbo.State", "StateId", cascadeDelete: true);
            AddForeignKey("dbo.Freelancer", "StateId", "dbo.State", "StateId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Freelancer", "StateId", "dbo.State");
            DropForeignKey("dbo.Employer", "StateId", "dbo.State");
            DropIndex("dbo.Freelancer", new[] { "StateId" });
            DropIndex("dbo.Employer", new[] { "StateId" });
            DropColumn("dbo.ApplicationUser", "UserRole");
            DropColumn("dbo.Freelancer", "StateId");
            DropColumn("dbo.Employer", "StateId");
        }
    }
}
