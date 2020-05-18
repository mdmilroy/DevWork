namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewAccountsMgmt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "FirstName", c => c.String());
            AddColumn("dbo.ApplicationUser", "LastName", c => c.String());
            AddColumn("dbo.ApplicationUser", "JoinedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Employer", "CreatedUTC");
            DropColumn("dbo.Employer", "ModifiedUTC");
            DropColumn("dbo.ApplicationUser", "UserRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "UserRole", c => c.String());
            AddColumn("dbo.Employer", "ModifiedUTC", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Employer", "CreatedUTC", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.ApplicationUser", "JoinedDate");
            DropColumn("dbo.ApplicationUser", "LastName");
            DropColumn("dbo.ApplicationUser", "FirstName");
        }
    }
}
