namespace TNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOrderAndOrderDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "TotalCNPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Orders", "TransportCNFree", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Orders", "OrderFee", c => c.Int());
            AddColumn("dbo.Orders", "ToTalCNPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Orders", "ExchangeRate", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Orders", "ToTalVNPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Orders", "WeightFee", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.OrderDetails", "VNPrice");
            DropColumn("dbo.OrderDetails", "ExchangeRate");
            DropColumn("dbo.Orders", "TransportPrice");
            DropColumn("dbo.Orders", "TotalTransportPrice");
            DropColumn("dbo.Orders", "TotalDeposit");
            DropColumn("dbo.Orders", "ToTalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ToTalPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Orders", "TotalDeposit", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Orders", "TotalTransportPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Orders", "TransportPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.OrderDetails", "ExchangeRate", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.OrderDetails", "VNPrice", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Orders", "WeightFee");
            DropColumn("dbo.Orders", "ToTalVNPrice");
            DropColumn("dbo.Orders", "ExchangeRate");
            DropColumn("dbo.Orders", "ToTalCNPrice");
            DropColumn("dbo.Orders", "OrderFee");
            DropColumn("dbo.Orders", "TransportCNFree");
            DropColumn("dbo.OrderDetails", "TotalCNPrice");
        }
    }
}
