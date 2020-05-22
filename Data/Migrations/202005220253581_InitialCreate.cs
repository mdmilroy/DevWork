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
                        FreelancerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CodingLanguageId)
                .ForeignKey("dbo.Freelancer", t => t.FreelancerId)
                .Index(t => t.FreelancerId);
            
            CreateTable(
                "dbo.Freelancer",
                c => new
                    {
                        FreelancerId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        JobsCompleted = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        StateId = c.Int(nullable: false),
                        CodingLanguage_CodingLanguageId = c.Int(),
                    })
                .PrimaryKey(t => t.FreelancerId)
                .ForeignKey("dbo.CodingLanguage", t => t.CodingLanguage_CodingLanguageId)
                .ForeignKey("dbo.State", t => t.StateId)
                .Index(t => t.StateId)
                .Index(t => t.CodingLanguage_CodingLanguageId);
            
            CreateTable(
                "dbo.JobPost",
                c => new
                    {
                        JobPostId = c.String(nullable: false, maxLength: 128),
                        JobTitle = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        StateName = c.String(),
                        IsAwarded = c.Boolean(nullable: false),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        EmployerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.JobPostId)
                .ForeignKey("dbo.Employer", t => t.EmployerId)
                .ForeignKey("dbo.Freelancer", t => t.JobPostId)
                .Index(t => t.JobPostId)
                .Index(t => t.EmployerId);
            
            CreateTable(
                "dbo.Employer",
                c => new
                    {
                        EmployerId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Organization = c.String(nullable: false),
                        Rating = c.Double(nullable: false),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(nullable: false, precision: 7),
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
                        SenderId = c.String(),
                        RecipientId = c.String(),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.JobPost", "JobPostId", "dbo.Freelancer");
            DropForeignKey("dbo.Freelancer", "StateId", "dbo.State");
            DropForeignKey("dbo.Employer", "StateId", "dbo.State");
            DropForeignKey("dbo.JobPost", "EmployerId", "dbo.Employer");
            DropForeignKey("dbo.CodingLanguage", "FreelancerId", "dbo.Freelancer");
            DropForeignKey("dbo.Freelancer", "CodingLanguage_CodingLanguageId", "dbo.CodingLanguage");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Employer", new[] { "StateId" });
            DropIndex("dbo.JobPost", new[] { "EmployerId" });
            DropIndex("dbo.JobPost", new[] { "JobPostId" });
            DropIndex("dbo.Freelancer", new[] { "CodingLanguage_CodingLanguageId" });
            DropIndex("dbo.Freelancer", new[] { "StateId" });
            DropIndex("dbo.CodingLanguage", new[] { "FreelancerId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Message");
            DropTable("dbo.State");
            DropTable("dbo.Employer");
            DropTable("dbo.JobPost");
            DropTable("dbo.Freelancer");
            DropTable("dbo.CodingLanguage");
        }
    }
}
