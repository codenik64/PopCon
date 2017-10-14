namespace PopsConfectionary14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "TotalO");
            DropColumn("dbo.Orders", "CreditCarholder");
            DropColumn("dbo.Orders", "expDate");
            DropColumn("dbo.Orders", "CreditcardNo");
            DropColumn("dbo.Orders", "CVV");
            DropColumn("dbo.Orders", "Status");
            DropColumn("dbo.Orders", "deliveryCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "deliveryCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "Status", c => c.String());
            AddColumn("dbo.Orders", "CVV", c => c.String());
            AddColumn("dbo.Orders", "CreditcardNo", c => c.String());
            AddColumn("dbo.Orders", "expDate", c => c.String());
            AddColumn("dbo.Orders", "CreditCarholder", c => c.String());
            AddColumn("dbo.Orders", "TotalO", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
