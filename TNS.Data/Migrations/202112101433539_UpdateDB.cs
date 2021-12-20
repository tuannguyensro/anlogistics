namespace TNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.PostCategories");
            DropForeignKey("dbo.PostTags", "PostID", "dbo.Posts");
            DropForeignKey("dbo.PostTags", "TagID", "dbo.Tags");
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropIndex("dbo.PostTags", new[] { "PostID" });
            DropIndex("dbo.PostTags", new[] { "TagID" });
            AlterColumn("dbo.OrderDetails", "ProductLink", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.OrderDetails", "Quantity", c => c.Int());
            AlterColumn("dbo.OrderDetails", "CNPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.OrderDetails", "VNPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.OrderDetails", "ExchangeRate", c => c.Decimal(precision: 18, scale: 2));
            CreateIndex("dbo.Orders", "CustomerId");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.ApplicationUsers", "Id");
            DropTable("dbo.PostCategories");
            DropTable("dbo.Posts");
            DropTable("dbo.PostTags");
            DropTable("dbo.Tags");
        }
        
        public override void Down()
        {
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
            
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.ApplicationUsers");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            AlterColumn("dbo.OrderDetails", "ExchangeRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderDetails", "VNPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderDetails", "CNPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderDetails", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "ProductLink", c => c.String(maxLength: 256));
            CreateIndex("dbo.PostTags", "TagID");
            CreateIndex("dbo.PostTags", "PostID");
            CreateIndex("dbo.Posts", "CategoryID");
            AddForeignKey("dbo.PostTags", "TagID", "dbo.Tags", "ID", cascadeDelete: true);
            AddForeignKey("dbo.PostTags", "PostID", "dbo.Posts", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "CategoryID", "dbo.PostCategories", "ID", cascadeDelete: true);
        }
    }
}
