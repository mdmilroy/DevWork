namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedStatesAndLanguagesClassToReplaceWithEnum : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CodingLanguage");
            DropTable("dbo.State");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.CodingLanguage",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        LanguageName = c.String(),
                    })
                .PrimaryKey(t => t.LanguageId);
            
        }
    }
}
