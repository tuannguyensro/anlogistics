namespace TNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thembangkygui : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PackageDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PackageID = c.Int(nullable: false),
                        TrackingID = c.String(maxLength: 256),
                        Description = c.String(maxLength: 750),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Packages", t => t.PackageID, cascadeDelete: true)
                .Index(t => t.PackageID);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PackageCode = c.String(maxLength: 128, unicode: false),
                        CustomerName = c.String(nullable: false, maxLength: 100),
                        CustomerAddress = c.String(nullable: false, maxLength: 250),
                        CustomerEmail = c.String(nullable: false, maxLength: 100),
                        CustomerMobile = c.String(maxLength: 50),
                        CustomerMessage = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128, unicode: false),
                        PaymentMethod = c.String(maxLength: 250),
                        PaymentStatus = c.Int(nullable: false),
                        CustomerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicationUsers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            AddColumn("dbo.Feedbacks", "Money", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Feedbacks", "CustomerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Feedbacks", "CustomerId");
            AddForeignKey("dbo.Feedbacks", "CustomerId", "dbo.ApplicationUsers", "Id");
            DropColumn("dbo.Feedbacks", "Website");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Feedbacks", "Website", c => c.String(maxLength: 100, unicode: false));
            DropForeignKey("dbo.PackageDetails", "PackageID", "dbo.Packages");
            DropForeignKey("dbo.Packages", "CustomerId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Feedbacks", "CustomerId", "dbo.ApplicationUsers");
            DropIndex("dbo.Packages", new[] { "CustomerId" });
            DropIndex("dbo.PackageDetails", new[] { "PackageID" });
            DropIndex("dbo.Feedbacks", new[] { "CustomerId" });
            DropColumn("dbo.Feedbacks", "CustomerId");
            DropColumn("dbo.Feedbacks", "Money");
            DropTable("dbo.Packages");
            DropTable("dbo.PackageDetails");
        }
    }
}
