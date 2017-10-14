namespace PopsConfectionary14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Payment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "CreditCarholder", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "expDate", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "CreditcardNo", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "CVV", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "Status", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "Status", c => c.String());
            AlterColumn("dbo.Payments", "CVV", c => c.String());
            AlterColumn("dbo.Payments", "CreditcardNo", c => c.String());
            AlterColumn("dbo.Payments", "expDate", c => c.String());
            AlterColumn("dbo.Payments", "CreditCarholder", c => c.String());
        }
    }
}
