using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.Data.Infrastructure;
using TNS.Model.Models;

namespace TNS.Data.Repositories
{
    public interface IPackageDetailRepository : IRepository<PackageDetail>
    {
    }

    public class PackageDetailRepository : RepositoryBase<PackageDetail>, IPackageDetailRepository
    {
        public PackageDetailRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

    }
}
