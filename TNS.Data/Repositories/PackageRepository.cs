using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.Common.ViewModels;
using TNS.Data.Infrastructure;
using TNS.Model.Models;

namespace TNS.Data.Repositories
{
    public interface IPackageRepository : IRepository<Package>
    {
        IEnumerable<PackageClientViewModel> GetListPackage(string userId);
    }

    public class PackageRepository : RepositoryBase<Package>, IPackageRepository
    {
        public PackageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<PackageClientViewModel> GetListPackage(string userId)
        {
            var parameter = new SqlParameter("@UserId", userId);
            return DbContext.Database.SqlQuery<PackageClientViewModel>("ListPackageCart @UserId", parameter);
        }
    }
}
