namespace PopsConfectionary14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CreditCarholder", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "expDate", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "CreditcardNo", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "CVV", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CVV");
            DropColumn("dbo.Orders", "CreditcardNo");
            DropColumn("dbo.Orders", "expDate");
            DropColumn("dbo.Orders", "CreditCarholder");
        }
    }
}
