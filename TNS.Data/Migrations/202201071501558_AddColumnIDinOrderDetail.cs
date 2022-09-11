namespace TNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnIDinOrderDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropPrimaryKey("dbo.OrderDetails");
            AddColumn("dbo.OrderDetails", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.OrderDetails", "ID");
            AddForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropPrimaryKey("dbo.OrderDetails");
            DropColumn("dbo.OrderDetails", "ID");
            AddPrimaryKey("dbo.OrderDetails", "OrderID");
            AddForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders", "ID");
        }
    }
}
