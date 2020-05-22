namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ApplicationUser", "UserRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "UserRole", c => c.String());
        }
    }
}
