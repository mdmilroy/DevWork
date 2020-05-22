namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedFreelancerCodingLangFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Freelancer", "CodingLanguage_CodingLanguageId", "dbo.CodingLanguage");
            DropForeignKey("dbo.CodingLanguage", "FreelancerId", "dbo.Freelancer");
            DropIndex("dbo.CodingLanguage", new[] { "FreelancerId" });
            DropIndex("dbo.Freelancer", new[] { "CodingLanguage_CodingLanguageId" });
            CreateTable(
                "dbo.FreelancerCodingLanguage",
                c => new
                    {
                        Freelancer_FreelancerId = c.String(nullable: false, maxLength: 128),
                        CodingLanguage_CodingLanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Freelancer_FreelancerId, t.CodingLanguage_CodingLanguageId })
                .ForeignKey("dbo.Freelancer", t => t.Freelancer_FreelancerId, cascadeDelete: true)
                .ForeignKey("dbo.CodingLanguage", t => t.CodingLanguage_CodingLanguageId, cascadeDelete: true)
                .Index(t => t.Freelancer_FreelancerId)
                .Index(t => t.CodingLanguage_CodingLanguageId);
            
            DropColumn("dbo.CodingLanguage", "FreelancerId");
            DropColumn("dbo.Freelancer", "CodingLanguage_CodingLanguageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Freelancer", "CodingLanguage_CodingLanguageId", c => c.Int());
            AddColumn("dbo.CodingLanguage", "FreelancerId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.FreelancerCodingLanguage", "CodingLanguage_CodingLanguageId", "dbo.CodingLanguage");
            DropForeignKey("dbo.FreelancerCodingLanguage", "Freelancer_FreelancerId", "dbo.Freelancer");
            DropIndex("dbo.FreelancerCodingLanguage", new[] { "CodingLanguage_CodingLanguageId" });
            DropIndex("dbo.FreelancerCodingLanguage", new[] { "Freelancer_FreelancerId" });
            DropTable("dbo.FreelancerCodingLanguage");
            CreateIndex("dbo.Freelancer", "CodingLanguage_CodingLanguageId");
            CreateIndex("dbo.CodingLanguage", "FreelancerId");
            AddForeignKey("dbo.CodingLanguage", "FreelancerId", "dbo.Freelancer", "FreelancerId");
            AddForeignKey("dbo.Freelancer", "CodingLanguage_CodingLanguageId", "dbo.CodingLanguage", "CodingLanguageId");
        }
    }
}
