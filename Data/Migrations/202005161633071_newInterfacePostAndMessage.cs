namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newInterfacePostAndMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPost", "FreelancerId", c => c.String());
            AddColumn("dbo.Message", "SenderId", c => c.Int(nullable: false));
            AddColumn("dbo.Message", "RecipientId", c => c.Int(nullable: false));
            DropColumn("dbo.Message", "EmployerId");
            DropColumn("dbo.Message", "FreelancerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "FreelancerId", c => c.String());
            AddColumn("dbo.Message", "EmployerId", c => c.String());
            DropColumn("dbo.Message", "RecipientId");
            DropColumn("dbo.Message", "SenderId");
            DropColumn("dbo.JobPost", "FreelancerId");
        }
    }
}
