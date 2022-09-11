namespace TNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifytable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetails", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "CNPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "TransportCNFree", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "OrderFee", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "ExchangeRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "WeightOrder", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "WeightFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.OrderDetails", "TotalCNPrice");
            DropColumn("dbo.Orders", "TotalOriginalPrice");
            DropColumn("dbo.Orders", "ToTalCNPrice");
            DropColumn("dbo.Orders", "ToTalVNPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ToTalVNPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Orders", "ToTalCNPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Orders", "TotalOriginalPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.OrderDetails", "TotalCNPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "WeightFee", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "WeightOrder", c => c.Int());
            AlterColumn("dbo.Orders", "ExchangeRate", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "OrderFee", c => c.Int());
            AlterColumn("dbo.Orders", "TransportCNFree", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.OrderDetails", "CNPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.OrderDetails", "Quantity", c => c.Int());
        }
    }
}
