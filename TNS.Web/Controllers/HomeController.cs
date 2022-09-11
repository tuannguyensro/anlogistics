using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNS.Model.Models;
using TNS.Service;
using TNS.Web.Models;

namespace TNS.Web.Controllers
{
    public class HomeController : Controller
    {
        IOrderDetailService _orderDetailService;
        public HomeController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        [OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            return View();
        }
        [OutputCache(Duration = 3600)]
        public ActionResult Introduce()
        {
            return View();
        }
        [OutputCache(Duration = 3600)]
        public ActionResult PriceTable()
        {
            return View();
        }
        [OutputCache(Duration = 3600)]
        public ActionResult Guide()
        {
            return View();
        }
        [OutputCache(Duration = 3600)]
        public ActionResult Policy()
        {
            return View();
        }
        [OutputCache(Duration = 3600)]
        public ActionResult Recruitment()
        {
            return View();
        }
        [OutputCache(Duration = 3600)]
        public ActionResult Contact()
        {
            return View();
        }
        [OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult UserIndex()
        {
            return View();
        }
        [OutputCache(Duration = 3600)]
        public ActionResult SearchByTrackingID(string keyword)
        {
            var orderdetailModel = _orderDetailService.SearchByTrackingID(keyword);
            var orderdetailViewModel = Mapper.Map<IEnumerable<OrderDetail>, IEnumerable<OrderDetailViewModel>>(orderdetailModel);
            ViewBag.Keyword = keyword;

            return View(orderdetailViewModel);
        }

    }
}