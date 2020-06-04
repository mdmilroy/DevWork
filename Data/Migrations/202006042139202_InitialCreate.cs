namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodingLanguage",
                c => new
                    {
                        CodingLanguageId = c.Int(nullable: false, identity: true),
                        CodingLanguageName = c.String(),
                    })
                .PrimaryKey(t => t.CodingLanguageId);
            
            CreateTable(
                "dbo.Freelancer",
                c => new
                    {
                        FreelancerId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        JobsCompleted = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsActive = c.Boolean(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FreelancerId)
                .ForeignKey("dbo.State", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.JobPost",
                c => new
                    {
                        JobPostId = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        Content = c.String(),
                        StateName = c.String(),
                        IsAwarded = c.Boolean(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsActive = c.Boolean(nullable: false),
                        EmployerId = c.String(nullable: false, maxLength: 128),
                        FreelancerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.JobPostId)
                .ForeignKey("dbo.Employer", t => t.EmployerId)
                .ForeignKey("dbo.Freelancer", t => t.FreelancerId)
                .Index(t => t.EmployerId)
                .Index(t => t.FreelancerId);
            
            CreateTable(
                "dbo.Employer",
                c => new
                    {
                        EmployerId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Organization = c.String(),
                        Rating = c.Double(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        JobsCompleted = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployerId)
                .ForeignKey("dbo.State", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        IsRead = c.Boolean(nullable: false),
                        SentDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsActive = c.Boolean(nullable: false),
                        SenderId = c.String(),
                        RecipientId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.ApplicationUser", t => t.RecipientId)
                .Index(t => t.RecipientId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserRole = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CodingLanguageFreelancer",
                c => new
                    {
                        FreelancerId = c.String(nullable: false, maxLength: 128),
                        CodingLanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FreelancerId, t.CodingLanguageId })
                .ForeignKey("dbo.Freelancer", t => t.FreelancerId, cascadeDelete: true)
                .ForeignKey("dbo.CodingLanguage", t => t.CodingLanguageId, cascadeDelete: true)
                .Index(t => t.FreelancerId)
                .Index(t => t.CodingLanguageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Message", "RecipientId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.JobPost", "FreelancerId", "dbo.Freelancer");
            DropForeignKey("dbo.Freelancer", "StateId", "dbo.State");
            DropForeignKey("dbo.Employer", "StateId", "dbo.State");
            DropForeignKey("dbo.JobPost", "EmployerId", "dbo.Employer");
            DropForeignKey("dbo.CodingLanguageFreelancer", "CodingLanguageId", "dbo.CodingLanguage");
            DropForeignKey("dbo.CodingLanguageFreelancer", "FreelancerId", "dbo.Freelancer");
            DropIndex("dbo.CodingLanguageFreelancer", new[] { "CodingLanguageId" });
            DropIndex("dbo.CodingLanguageFreelancer", new[] { "FreelancerId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Message", new[] { "RecipientId" });
            DropIndex("dbo.Employer", new[] { "StateId" });
            DropIndex("dbo.JobPost", new[] { "FreelancerId" });
            DropIndex("dbo.JobPost", new[] { "EmployerId" });
            DropIndex("dbo.Freelancer", new[] { "StateId" });
            DropTable("dbo.CodingLanguageFreelancer");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Message");
            DropTable("dbo.State");
            DropTable("dbo.Employer");
            DropTable("dbo.JobPost");
            DropTable("dbo.Freelancer");
            DropTable("dbo.CodingLanguage");
        }
    }
}
