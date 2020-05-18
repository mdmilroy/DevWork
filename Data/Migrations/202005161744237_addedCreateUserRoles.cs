namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCreateUserRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "UserRole", c => c.String());
            AddColumn("dbo.ApplicationUser", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "Age");
            DropColumn("dbo.ApplicationUser", "UserRole");
        }
    }
}
