namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedStateForJobPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPost", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.JobPost", "StateId");
            AddForeignKey("dbo.JobPost", "StateId", "dbo.State", "StateId");
            DropColumn("dbo.JobPost", "StateName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobPost", "StateName", c => c.String());
            DropForeignKey("dbo.JobPost", "StateId", "dbo.State");
            DropIndex("dbo.JobPost", new[] { "StateId" });
            DropColumn("dbo.JobPost", "StateId");
        }
    }
}
