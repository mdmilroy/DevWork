namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class swappedKeysInCodingFreelancerTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CodingLanguageFreelancer", new[] { "CodingLanguageId" });
            DropIndex("dbo.CodingLanguageFreelancer", new[] { "FreelancerId" });
            RenameColumn(table: "dbo.CodingLanguageFreelancer", name: "CodingLanguageId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.CodingLanguageFreelancer", name: "FreelancerId", newName: "CodingLanguageId");
            RenameColumn(table: "dbo.CodingLanguageFreelancer", name: "__mig_tmp__0", newName: "FreelancerId");
            DropPrimaryKey("dbo.CodingLanguageFreelancer");
            AlterColumn("dbo.CodingLanguageFreelancer", "CodingLanguageId", c => c.Int(nullable: false));
            AlterColumn("dbo.CodingLanguageFreelancer", "FreelancerId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.CodingLanguageFreelancer", new[] { "FreelancerId", "CodingLanguageId" });
            CreateIndex("dbo.CodingLanguageFreelancer", "FreelancerId");
            CreateIndex("dbo.CodingLanguageFreelancer", "CodingLanguageId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CodingLanguageFreelancer", new[] { "CodingLanguageId" });
            DropIndex("dbo.CodingLanguageFreelancer", new[] { "FreelancerId" });
            DropPrimaryKey("dbo.CodingLanguageFreelancer");
            AlterColumn("dbo.CodingLanguageFreelancer", "FreelancerId", c => c.Int(nullable: false));
            AlterColumn("dbo.CodingLanguageFreelancer", "CodingLanguageId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.CodingLanguageFreelancer", new[] { "CodingLanguageId", "FreelancerId" });
            RenameColumn(table: "dbo.CodingLanguageFreelancer", name: "FreelancerId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.CodingLanguageFreelancer", name: "CodingLanguageId", newName: "FreelancerId");
            RenameColumn(table: "dbo.CodingLanguageFreelancer", name: "__mig_tmp__0", newName: "CodingLanguageId");
            CreateIndex("dbo.CodingLanguageFreelancer", "FreelancerId");
            CreateIndex("dbo.CodingLanguageFreelancer", "CodingLanguageId");
        }
    }
}
