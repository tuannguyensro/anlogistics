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
    public interface IOrderDetailService : ICrudService<OrderDetail>, IGetDataService<OrderDetail>
    {
        IEnumerable<OrderDetail> ListOrderDetailByOrderID(int id);
        IEnumerable<OrderDetail> SearchByTrackingID(string keyword);
    }
    public class OrderDetailService : IOrderDetailService
    {
        //private IOrderRepository _orderRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IUnitOfWork _unitOfWork;
        public OrderDetailService(/*IOrderRepository orderRepository,*/ IUnitOfWork unitOfWork,
            IOrderDetailRepository orderDetailRepository)
        {
            //_orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _orderDetailRepository = orderDetailRepository;
        }
        public OrderDetail Add(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            _orderDetailRepository.Delete(id);
        }

        public OrderDetail FindById(int id)
        {
            return _orderDetailRepository.GetSingleById(id);
        }

        public IEnumerable<OrderDetail> GetAll(string keyword = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetail> ListOrderDetailByOrderID(int id)
        {
            return _orderDetailRepository.GetMulti(x => x.OrderID == id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<OrderDetail> SearchByTrackingID(string keyword)
        {
           return _orderDetailRepository.GetMulti(x => x.TrackingID.Contains(keyword));
        }

        public void Update(OrderDetail entity)
        {
            _orderDetailRepository.Update(entity);
        }

    }
}
