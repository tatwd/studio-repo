namespace MvcSignPage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Telephone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Telephone", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 60));
        }
    }
}
