using System.Collections.Generic;
using System.Data.SqlClient;
using TNS.Common.ViewModels;
using TNS.Data.Infrastructure;
using TNS.Model.Models;

namespace TNS.Data.Repositories
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        IEnumerable<OrderDetailClientViewModel> GetListOrderDetail(string OrderID);
    }

    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<OrderDetailClientViewModel> GetListOrderDetail(string OrderID)
        {
            var parameter = new SqlParameter("@OrderID", OrderID);
            return DbContext.Database.SqlQuery<OrderDetailClientViewModel>("ListOrderDetail @OrderID", parameter);
        }
    }
}