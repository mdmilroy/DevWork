namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employer",
                c => new
                    {
                        EmployerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Rating = c.Double(nullable: false),
                        Organization = c.String(),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployerId);
            
            CreateTable(
                "dbo.Freelancer",
                c => new
                    {
                        FreelancerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Rating = c.Double(nullable: false),
                        CodingLanguage = c.Int(nullable: false),
                        JobsCompleted = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FreelancerId);
            
            CreateTable(
                "dbo.JobPost",
                c => new
                    {
                        JobPostId = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        Content = c.String(),
                        EmployerId = c.Int(nullable: false),
                        IsAwarded = c.Boolean(nullable: false),
                        State = c.Int(nullable: false),
                        FreelancerId = c.Int(nullable: false),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.JobPostId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        SenderId = c.Int(nullable: false),
                        RecipientId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(nullable: false, precision: 7),
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
                        Age = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
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
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Message");
            DropTable("dbo.JobPost");
            DropTable("dbo.Freelancer");
            DropTable("dbo.Employer");
        }
    }
}
