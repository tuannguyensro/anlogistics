namespace TNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddListOrderDetail1 : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("ListOrderDetail",
            p => new
            {
                OrderID = p.String()
            },
            @"select od.ID, od.CreatedDate, od.OrderCode, od.CustomerName, od.CustomerAddress, od.CustomerEmail, od.CustomerMobile, od.CustomerMessage, od.WeightOrder, od.TransportPrice, od.TotalTransportPrice, od.TotalOriginalPrice, od.TotalDeposit, od.ToTalPrice, od.CreatedBy, od.PaymentMethod, od.PaymentStatus,
                   odt.ID, odt.TrackingID, odt.ProductLink, odt.ProductImage, odt.ProductDetail, odt.Description, odt.Quantity, odt.CNPrice, odt.VNPrice, odt.ExchangeRate
                   from Orders od
                   inner join OrderDetails odt on odt.OrderID =  od.ID
                   where (od.ID = @OrderID)");
        }

        public override void Down()
        {
            DropStoredProcedure("ListOrderDetail");
        }
    }
}
