namespace TNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ListOrderCart : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("ListOrderCart",
            p => new
            {
                UserId = p.String()
            },
            @"select O.ID, O.CustomerName, O.CustomerAddress, O.CustomerEmail, O.CustomerMobile, O.CustomerMessage,
           		                 O.WeightOrder, O.TransportPrice, O.TotalTransportPrice, O.TotalOriginalPrice, O.ToTalPrice, O.CreatedDate, O.CreatedBy, O.PaymentMethod,
           		                 O. PaymentStatus, O.TotalDeposit, O.OrderCode
                            from Orders O
                            inner join ApplicationUsers u on u.Id = O.CustomerId
                            where O.CustomerId =  @UserId");
        }

        public override void Down()
        {
            DropStoredProcedure("ListOrderCart");
        }
    }
}
