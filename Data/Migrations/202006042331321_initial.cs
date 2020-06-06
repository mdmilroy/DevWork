namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Message", name: "RecipientId", newName: "Recipient_Id");
            RenameIndex(table: "dbo.Message", name: "IX_RecipientId", newName: "IX_Recipient_Id");
            AddColumn("dbo.Freelancer", "FullName", c => c.String());
            AddColumn("dbo.Employer", "FullName", c => c.String());
            AddColumn("dbo.Message", "Sender", c => c.String());
            AddColumn("dbo.Message", "Receiver", c => c.String());
            DropColumn("dbo.Message", "SenderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "SenderId", c => c.String());
            DropColumn("dbo.Message", "Receiver");
            DropColumn("dbo.Message", "Sender");
            DropColumn("dbo.Employer", "FullName");
            DropColumn("dbo.Freelancer", "FullName");
            RenameIndex(table: "dbo.Message", name: "IX_Recipient_Id", newName: "IX_RecipientId");
            RenameColumn(table: "dbo.Message", name: "Recipient_Id", newName: "RecipientId");
        }
    }
}
