namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedCreatedAndModifiedDates : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.JobPost", "CreatedUTC");
            DropColumn("dbo.JobPost", "ModifiedUTC");
            DropColumn("dbo.Message", "CreatedUTC");
            DropColumn("dbo.Message", "ModifiedUTC");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "ModifiedUTC", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Message", "CreatedUTC", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.JobPost", "ModifiedUTC", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.JobPost", "CreatedUTC", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
