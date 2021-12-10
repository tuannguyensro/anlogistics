namespace TNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetable2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            AddColumn("dbo.OrderDetails", "ProductLink", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.OrderDetails", "ProductImage", c => c.String(maxLength: 256));
            AddColumn("dbo.OrderDetails", "ProductDetail", c => c.String(maxLength: 256));
            AddColumn("dbo.OrderDetails", "Description", c => c.String(maxLength: 750));
            AddColumn("dbo.OrderDetails", "Quantity", c => c.Int());
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ProductLink = c.String(nullable: false, maxLength: 256),
                        ProductImage = c.String(maxLength: 256),
                        ProductDetail = c.String(maxLength: 256),
                        Description = c.String(maxLength: 750),
                        Quantity = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.OrderDetails", "Quantity");
            DropColumn("dbo.OrderDetails", "Description");
            DropColumn("dbo.OrderDetails", "ProductDetail");
            DropColumn("dbo.OrderDetails", "ProductImage");
            DropColumn("dbo.OrderDetails", "ProductLink");
            CreateIndex("dbo.OrderDetails", "ProductID");
            AddForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
    }
}
