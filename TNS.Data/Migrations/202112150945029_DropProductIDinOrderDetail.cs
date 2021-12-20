namespace TNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropProductIDinOrderDetail : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderDetails", "ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "ProductID", c => c.Int(nullable: false, identity: true));
        }
    }
}
