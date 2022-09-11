using System.Collections.Generic;
using System.Data.SqlClient;
using TNS.Common.ViewModels;
using TNS.Data.Infrastructure;
using TNS.Model.Models;

namespace TNS.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);

        IEnumerable<Order> GetListOrder(string userId);
    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<Order> GetListOrder(string userId)
        {
            var parameter = new SqlParameter("@UserId", userId);
            return DbContext.Database.SqlQuery<Order>("ListOrderCart @UserId", parameter);
        }

        public IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@fromDate", fromDate),
                new SqlParameter("@toDate", toDate)
            };
            return DbContext.Database.SqlQuery<RevenueStatisticViewModel>("GetRevenuesStatistic  @fromDate,@toDate", parameters);
        }
    }
}