namespace PopsConfectionary14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Status", c => c.String());
            AddColumn("dbo.Orders", "PaymentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PaymentType");
            DropColumn("dbo.Orders", "Status");
        }
    }
}
