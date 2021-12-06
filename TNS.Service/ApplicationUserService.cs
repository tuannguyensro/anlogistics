﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.Data.Infrastructure;
using TNS.Data.Repositories;
using TNS.Model.Models;

namespace TNS.Service
{
    public interface IApplicationUserService
    {
        ApplicationUser GetUserById(string userId);

        IEnumerable<string> GetUserIdByGroupId(int id);

        void SetViewed(string id);

        void IsDeleted(string id);

        void SaveChanges();
    }

    public class ApplicationUserService : IApplicationUserService
    {
        private IApplicationUserRepository _applicationUserRepository;
        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(IApplicationUserRepository applicationUserRepository,
            IUnitOfWork unitOfWork)
        {
            _applicationUserRepository = applicationUserRepository;
            _unitOfWork = unitOfWork;
        }

        public ApplicationUser GetUserById(string userId)
        {
            return _applicationUserRepository.GetSingleById(userId);
        }

        public IEnumerable<string> GetUserIdByGroupId(int id)
        {
            return _applicationUserRepository.GetUserIdByGroupId(id);
        }

        public void IsDeleted(string id)
        {
            var user = _applicationUserRepository.GetSingleById(id);
            user.IsDeleted = true;
            _applicationUserRepository.Update(user);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }


        public void SetViewed(string id)
        {
            var user = _applicationUserRepository.GetSingleById(id);
            user.IsViewed = true;
            _applicationUserRepository.Update(user);
            SaveChanges();
        }
    }
}
