namespace YunKe.Commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefineMembers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "QQ", c => c.String(maxLength: 32));
            AddColumn("dbo.Members", "CompanyName", c => c.String(maxLength: 256));
            AddColumn("dbo.Members", "WebSite", c => c.String(maxLength: 256));
            AlterColumn("dbo.Members", "Name", c => c.String(maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Name", c => c.String(maxLength: 16));
            DropColumn("dbo.Members", "WebSite");
            DropColumn("dbo.Members", "CompanyName");
            DropColumn("dbo.Members", "QQ");
        }
    }
}
