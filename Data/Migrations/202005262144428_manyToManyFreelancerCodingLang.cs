namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manyToManyFreelancerCodingLang : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CodingLanguageFreelancer", name: "CodingLanguage_CodingLanguageId", newName: "FreelancerId");
            RenameColumn(table: "dbo.CodingLanguageFreelancer", name: "Freelancer_FreelancerId", newName: "CodingLanguageId");
            RenameIndex(table: "dbo.CodingLanguageFreelancer", name: "IX_Freelancer_FreelancerId", newName: "IX_CodingLanguageId");
            RenameIndex(table: "dbo.CodingLanguageFreelancer", name: "IX_CodingLanguage_CodingLanguageId", newName: "IX_FreelancerId");
            DropPrimaryKey("dbo.CodingLanguageFreelancer");
            AddPrimaryKey("dbo.CodingLanguageFreelancer", new[] { "CodingLanguageId", "FreelancerId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CodingLanguageFreelancer");
            AddPrimaryKey("dbo.CodingLanguageFreelancer", new[] { "CodingLanguage_CodingLanguageId", "Freelancer_FreelancerId" });
            RenameIndex(table: "dbo.CodingLanguageFreelancer", name: "IX_FreelancerId", newName: "IX_CodingLanguage_CodingLanguageId");
            RenameIndex(table: "dbo.CodingLanguageFreelancer", name: "IX_CodingLanguageId", newName: "IX_Freelancer_FreelancerId");
            RenameColumn(table: "dbo.CodingLanguageFreelancer", name: "CodingLanguageId", newName: "Freelancer_FreelancerId");
            RenameColumn(table: "dbo.CodingLanguageFreelancer", name: "FreelancerId", newName: "CodingLanguage_CodingLanguageId");
        }
    }
}
