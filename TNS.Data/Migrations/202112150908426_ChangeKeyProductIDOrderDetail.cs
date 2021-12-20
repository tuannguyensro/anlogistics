namespace TNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeKeyProductIDOrderDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropPrimaryKey("dbo.OrderDetails");
            AddPrimaryKey("dbo.OrderDetails", "OrderID");
            AddForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropPrimaryKey("dbo.OrderDetails");
            AddPrimaryKey("dbo.OrderDetails", new[] { "OrderID", "ProductID" });
            AddForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders", "ID", cascadeDelete: true);
        }
    }
}
