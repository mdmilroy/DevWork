namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rekeyedFreelancerLanguages : DbMigration
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
                "dbo.CodingLanguageFreelancer",
                c => new
                    {
                        CodingLanguage_CodingLanguageId = c.Int(nullable: false),
                        Freelancer_FreelancerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CodingLanguage_CodingLanguageId, t.Freelancer_FreelancerId })
                .ForeignKey("dbo.CodingLanguage", t => t.CodingLanguage_CodingLanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Freelancer", t => t.Freelancer_FreelancerId, cascadeDelete: true)
                .Index(t => t.CodingLanguage_CodingLanguageId)
                .Index(t => t.Freelancer_FreelancerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CodingLanguageFreelancer", "Freelancer_FreelancerId", "dbo.Freelancer");
            DropForeignKey("dbo.CodingLanguageFreelancer", "CodingLanguage_CodingLanguageId", "dbo.CodingLanguage");
            DropIndex("dbo.CodingLanguageFreelancer", new[] { "Freelancer_FreelancerId" });
            DropIndex("dbo.CodingLanguageFreelancer", new[] { "CodingLanguage_CodingLanguageId" });
            DropTable("dbo.CodingLanguageFreelancer");
            DropTable("dbo.CodingLanguage");
        }
    }
}
