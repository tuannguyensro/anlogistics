namespace TNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProductIDLongtoInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetails", "ProductID", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "ProductID", c => c.Long(nullable: false, identity: true));
        }
    }
}
