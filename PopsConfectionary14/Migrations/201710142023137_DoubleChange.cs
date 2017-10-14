namespace PopsConfectionary14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoubleChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Orders", "DeliveryCost", c => c.Double(nullable: false));
            AlterColumn("dbo.Orders", "Total", c => c.Double(nullable: false));
            AlterColumn("dbo.OrderDetails", "UnitPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Payments", "deliveryCost", c => c.Double(nullable: false));
            AlterColumn("dbo.Payments", "Total", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Payments", "deliveryCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderDetails", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "DeliveryCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "ProductPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
