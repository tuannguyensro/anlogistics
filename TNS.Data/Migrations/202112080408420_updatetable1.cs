namespace TNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "CNPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.OrderDetails", "VNPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.OrderDetails", "ExchangeRate", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Products", "CNPrice");
            DropColumn("dbo.Products", "VNPrice");
            DropColumn("dbo.Products", "ExchangeRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ExchangeRate", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Products", "VNPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Products", "CNPrice", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.OrderDetails", "ExchangeRate");
            DropColumn("dbo.OrderDetails", "VNPrice");
            DropColumn("dbo.OrderDetails", "CNPrice");
        }
    }
}
