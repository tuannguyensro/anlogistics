namespace TNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.PostCategories");
            DropForeignKey("dbo.PostTags", "PostID", "dbo.Posts");
            DropForeignKey("dbo.PostTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.TrackOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.TrackOrders", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropIndex("dbo.PostTags", new[] { "PostID" });
            DropIndex("dbo.PostTags", new[] { "TagID" });
            DropIndex("dbo.TrackOrders", new[] { "OrderId" });
            DropIndex("dbo.TrackOrders", new[] { "VehicleId" });
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ProductLink = c.String(nullable: false, maxLength: 256),
                        ProductImage = c.String(maxLength: 256),
                        ProductDetail = c.String(maxLength: 256),
                        CNPrice = c.Decimal(precision: 18, scale: 2),
                        VNPrice = c.Decimal(precision: 18, scale: 2),
                        ExchangeRate = c.Decimal(precision: 18, scale: 2),
                        Description = c.String(maxLength: 750),
                        Quantity = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.OrderDetails", "ProductID");
            CreateIndex("dbo.Orders", "CustomerId");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.ApplicationUsers", "Id");
            AddForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
            DropColumn("dbo.OrderDetails", "ProductLink");
            DropColumn("dbo.OrderDetails", "ProductImage");
            DropColumn("dbo.OrderDetails", "ProductDetail");
            DropColumn("dbo.OrderDetails", "Quantity");
            DropColumn("dbo.OrderDetails", "CNPrice");
            DropColumn("dbo.OrderDetails", "VNPrice");
            DropColumn("dbo.OrderDetails", "ExchangeRate");
            DropColumn("dbo.OrderDetails", "Description");
            DropTable("dbo.PostCategories");
            DropTable("dbo.Posts");
            DropTable("dbo.PostTags");
            DropTable("dbo.Tags");
            DropTable("dbo.TrackOrders");
            DropTable("dbo.Vehicles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VehicleNumber = c.String(maxLength: 30, unicode: false),
                        DriverName = c.String(maxLength: 100),
                        Name = c.String(maxLength: 100),
                        ModelID = c.String(maxLength: 50),
                        Model = c.String(maxLength: 150),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 50),
                        MetaKeyword = c.String(maxLength: 150),
                        MetaDescription = c.String(maxLength: 150),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TrackOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Longitude = c.String(),
                        Latitude = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        Type = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PostTags",
                c => new
                    {
                        PostID = c.Long(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.PostID, t.TagID });
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                        CategoryID = c.Int(nullable: false),
                        Image = c.String(maxLength: 256),
                        Description = c.String(maxLength: 750),
                        Content = c.String(nullable: false),
                        HomeFlag = c.Boolean(),
                        HotFlag = c.Boolean(),
                        ViewCount = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 50),
                        MetaKeyword = c.String(maxLength: 150),
                        MetaDescription = c.String(maxLength: 150),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                        Description = c.String(maxLength: 500),
                        ParentID = c.Int(),
                        DisplayOrder = c.Int(),
                        Image = c.String(maxLength: 256),
                        HomeFlag = c.Boolean(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 50),
                        MetaKeyword = c.String(maxLength: 150),
                        MetaDescription = c.String(maxLength: 150),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.OrderDetails", "Description", c => c.String(maxLength: 750));
            AddColumn("dbo.OrderDetails", "ExchangeRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderDetails", "VNPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderDetails", "CNPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderDetails", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "ProductDetail", c => c.String(maxLength: 256));
            AddColumn("dbo.OrderDetails", "ProductImage", c => c.String(maxLength: 256));
            AddColumn("dbo.OrderDetails", "ProductLink", c => c.String(maxLength: 256));
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.ApplicationUsers");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropTable("dbo.Products");
            CreateIndex("dbo.TrackOrders", "VehicleId");
            CreateIndex("dbo.TrackOrders", "OrderId");
            CreateIndex("dbo.PostTags", "TagID");
            CreateIndex("dbo.PostTags", "PostID");
            CreateIndex("dbo.Posts", "CategoryID");
            AddForeignKey("dbo.TrackOrders", "VehicleId", "dbo.Vehicles", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TrackOrders", "OrderId", "dbo.Orders", "ID", cascadeDelete: true);
            AddForeignKey("dbo.PostTags", "TagID", "dbo.Tags", "ID", cascadeDelete: true);
            AddForeignKey("dbo.PostTags", "PostID", "dbo.Posts", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "CategoryID", "dbo.PostCategories", "ID", cascadeDelete: true);
        }
    }
}
