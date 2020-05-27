namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdSoftDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Freelancer", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobPost", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employer", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Message", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Message", "IsActive");
            DropColumn("dbo.Employer", "IsActive");
            DropColumn("dbo.JobPost", "IsActive");
            DropColumn("dbo.Freelancer", "IsActive");
        }
    }
}
