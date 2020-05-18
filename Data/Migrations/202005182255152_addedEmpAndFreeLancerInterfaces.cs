namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedEmpAndFreeLancerInterfaces : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Freelancer", "CreatedUTC");
            DropColumn("dbo.Freelancer", "ModifiedUTC");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Freelancer", "ModifiedUTC", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Freelancer", "CreatedUTC", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
