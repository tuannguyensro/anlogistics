﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.Data.Infrastructure;
using TNS.Data.Repositories;
using uStora.Model.Models;

namespace TNS.Service
{

    public interface IErrorService
    {
        Error Create(Error error);

        void SaveChange();
    }

    public class ErrorService : IErrorService
    {
        private IErrorRepository _errorRepository;
        private IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        public Error Create(Error error)
        {
            return _errorRepository.Add(error);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }
    }
}
