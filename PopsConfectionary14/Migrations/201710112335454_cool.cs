namespace PopsConfectionary14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cool : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PID = c.Int(nullable: false, identity: true),
                        CreditCarholder = c.String(),
                        expDate = c.String(),
                        CreditcardNo = c.String(),
                        CVV = c.String(),
                        Status = c.String(),
                        deliveryCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Payments");
        }
    }
}
