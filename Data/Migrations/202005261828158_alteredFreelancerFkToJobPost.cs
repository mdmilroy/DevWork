namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteredFreelancerFkToJobPost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobPost", "JobPostId", "dbo.Freelancer");
            DropIndex("dbo.JobPost", new[] { "JobPostId" });
            DropPrimaryKey("dbo.JobPost");
            AddColumn("dbo.Employer", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Employer", "ModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Employer", "JobsCompleted", c => c.Int(nullable: false));
            AddColumn("dbo.JobPost", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.JobPost", "ModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.JobPost", "FreelancerId", c => c.String(maxLength: 128));
            AddColumn("dbo.Freelancer", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Freelancer", "ModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Message", "SentDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Message", "ModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Employer", "FirstName", c => c.String());
            AlterColumn("dbo.Employer", "LastName", c => c.String());
            AlterColumn("dbo.Employer", "Organization", c => c.String());
            AlterColumn("dbo.JobPost", "JobPostId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.JobPost", "JobTitle", c => c.String());
            AlterColumn("dbo.JobPost", "Content", c => c.String());
            AlterColumn("dbo.Freelancer", "FirstName", c => c.String());
            AlterColumn("dbo.Freelancer", "LastName", c => c.String());
            AddPrimaryKey("dbo.JobPost", "JobPostId");
            CreateIndex("dbo.JobPost", "FreelancerId");
            AddForeignKey("dbo.JobPost", "FreelancerId", "dbo.Freelancer", "FreelancerId");
            DropColumn("dbo.Employer", "CreatedUTC");
            DropColumn("dbo.Employer", "ModifiedUTC");
            DropColumn("dbo.JobPost", "CreatedUTC");
            DropColumn("dbo.JobPost", "ModifiedUTC");
            DropColumn("dbo.Freelancer", "CreatedUTC");
            DropColumn("dbo.Freelancer", "ModifiedUTC");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Freelancer", "ModifiedUTC", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Freelancer", "CreatedUTC", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.JobPost", "ModifiedUTC", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.JobPost", "CreatedUTC", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Employer", "ModifiedUTC", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Employer", "CreatedUTC", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropForeignKey("dbo.JobPost", "FreelancerId", "dbo.Freelancer");
            DropIndex("dbo.JobPost", new[] { "FreelancerId" });
            DropPrimaryKey("dbo.JobPost");
            AlterColumn("dbo.Freelancer", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Freelancer", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.JobPost", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.JobPost", "JobTitle", c => c.String(nullable: false));
            AlterColumn("dbo.JobPost", "JobPostId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Employer", "Organization", c => c.String(nullable: false));
            AlterColumn("dbo.Employer", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Employer", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.Message", "ModifiedDate");
            DropColumn("dbo.Message", "SentDate");
            DropColumn("dbo.Freelancer", "ModifiedDate");
            DropColumn("dbo.Freelancer", "CreatedDate");
            DropColumn("dbo.JobPost", "FreelancerId");
            DropColumn("dbo.JobPost", "ModifiedDate");
            DropColumn("dbo.JobPost", "CreatedDate");
            DropColumn("dbo.Employer", "JobsCompleted");
            DropColumn("dbo.Employer", "ModifiedDate");
            DropColumn("dbo.Employer", "CreatedDate");
            AddPrimaryKey("dbo.JobPost", "JobPostId");
            CreateIndex("dbo.JobPost", "JobPostId");
            AddForeignKey("dbo.JobPost", "JobPostId", "dbo.Freelancer", "FreelancerId");
        }
    }
}
