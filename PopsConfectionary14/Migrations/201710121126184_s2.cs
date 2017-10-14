namespace PopsConfectionary14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Cname", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Clients", "Surname", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Clients", "Address", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Clients", "Contact", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Clients", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Email", c => c.String());
            AlterColumn("dbo.Clients", "Contact", c => c.String());
            AlterColumn("dbo.Clients", "Address", c => c.String());
            AlterColumn("dbo.Clients", "Surname", c => c.String());
            AlterColumn("dbo.Clients", "Cname", c => c.String());
        }
    }
}
