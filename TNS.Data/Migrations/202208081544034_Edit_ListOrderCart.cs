namespace TNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_ListOrderCart : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("ListOrderCart",
            p => new
            {
                UserId = p.String()
            },
            @"select * from Orders O
                            inner join ApplicationUsers u on u.Id = O.CustomerId
                            where O.CustomerId =  @UserId");
        }
        
        public override void Down()
        {
            DropStoredProcedure("ListOrderCart");
        }
    }
}
