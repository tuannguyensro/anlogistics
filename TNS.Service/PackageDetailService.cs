using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.Common.Services.Int32;
using TNS.Data.Infrastructure;
using TNS.Data.Repositories;
using TNS.Model.Models;

namespace TNS.Service
{
    public interface IPackageDetailService : ICrudService<PackageDetail>, IGetDataService<PackageDetail>
    {
        IEnumerable<PackageDetail> ListPackageDetailByPackageID(int id);
    }

    public class PackageDetailService : IPackageDetailService
    {
        private IPackageDetailRepository _packageDetailRepository;
        private IUnitOfWork _unitOfWork;
        public PackageDetailService(/*IOrderRepository orderRepository,*/ IUnitOfWork unitOfWork,
            IPackageDetailRepository packageDetailRepository)
        {
            //_orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _packageDetailRepository = packageDetailRepository;
        }
        public PackageDetail Add(PackageDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            _packageDetailRepository.Delete(id);
        }

        public PackageDetail FindById(int id)
        {
            return _packageDetailRepository.GetSingleById(id);
        }

        public IEnumerable<PackageDetail> GetAll(string keyword = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PackageDetail> ListPackageDetailByPackageID(int id)
        {
            return _packageDetailRepository.GetMulti(x => x.PackageID == id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(PackageDetail entity)
        {
            _packageDetailRepository.Update(entity);
        }
    }
}
