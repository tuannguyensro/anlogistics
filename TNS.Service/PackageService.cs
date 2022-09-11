using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.Common.Services.Int32;
using TNS.Common.ViewModels;
using TNS.Data.Infrastructure;
using TNS.Data.Repositories;
using TNS.Model.Models;

namespace TNS.Service
{
    public interface IPackageService :ICrudService<Package>, IGetDataService<Package>
    {
        Package Add(ref Package package, List<PackageDetail> packageDetails);
        IEnumerable<PackageClientViewModel> GetListPackages(string userId);
        IEnumerable<PackageDetail> ListDetailByPackageID(int id);
    }
    public class PackageService : IPackageService
    {
        private IPackageRepository _packageRepository;
        private IPackageDetailRepository _packageDetailRepository;
        private IUnitOfWork _unitOfWork;
        public PackageService(IPackageRepository packageRepository, IUnitOfWork unitOfWork,
            IPackageDetailRepository packageDetailRepository)
        {
            _packageRepository = packageRepository;
            _unitOfWork = unitOfWork;
            _packageDetailRepository = packageDetailRepository;
        }
        public Package Add(Package entity)
        {
            return _packageRepository.Add(entity);
        }

        public Package Add(ref Package package, List<PackageDetail> packageDetails)
        {
            try
            {
                _packageRepository.Add(package);
                _unitOfWork.Commit();
                foreach (var packageDetail in packageDetails)
                {
                    packageDetail.PackageID = package.ID;
                    _packageDetailRepository.Add(packageDetail);
                }
                return package;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public void Delete(int id)
        {
            _packageRepository.Delete(id);
        }

        public Package FindById(int id)
        {
            return _packageRepository.GetSingleById(id);
        }

        public IEnumerable<Package> GetAll(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return _packageRepository.GetAll();
            else
                return _packageRepository.GetMulti(x => x.PackageCode.Contains(keyword));
        }

        public IEnumerable<PackageClientViewModel> GetListPackages(string userId)
        {
            return _packageRepository.GetListPackage(userId).OrderBy(x => x.CreatedDate).ToList();
        }

        public IEnumerable<PackageDetail> ListDetailByPackageID(int id)
        {
            return _packageDetailRepository.GetMulti(x => x.PackageID == id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Package entity)
        {
            _packageRepository.Update(entity);
        }
    }
}
