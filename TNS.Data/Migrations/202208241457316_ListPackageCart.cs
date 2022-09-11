namespace TNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListPackageCart : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("ListPackageCart",
            p => new
            {
                UserId = p.String()
            },
            @"select * from Packages P
                            inner join ApplicationUsers u on u.Id = P.CustomerId
                            where P.CustomerId =  @UserId");
        }

        public override void Down()
        {
            DropStoredProcedure("ListPackageCart");
        }
    }
}
