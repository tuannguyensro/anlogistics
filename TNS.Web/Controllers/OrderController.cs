using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TNS.Common;
using TNS.Model.Models;
using TNS.Service;
using TNS.Web.App_Start;
using TNS.Web.Infrastructure.Extensions;
using TNS.Web.Models;

namespace TNS.Web.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private ApplicationUserManager _userManager;

        public OrderController(ApplicationUserManager userManager, IOrderService orderService)
        {
            _userManager = userManager;
            _orderService = orderService;
        }
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add()
        {
            var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.ShoppingCartSession];
            if (cart == null)
            {
                cart = new List<ShoppingCartViewModel>();
            }
            else
            {
                ShoppingCartViewModel newItem = new ShoppingCartViewModel();
                newItem.Quantity = 1;
                cart.Add(newItem);
            }
            Session[CommonConstants.ShoppingCartSession] = cart;
            return Json(new
            {
                status = true
            });
        }
        [AllowAnonymous]
        [HttpPost]
        public JsonResult DeleteAll()
        {
            Session[CommonConstants.ShoppingCartSession] = new List<ShoppingCartViewModel>();

            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public ActionResult CreateOrder(string orderViewModel)
        {
            if (!Request.IsAuthenticated)
            {
                return Json(new { status = false });
            }
            var order = new JavaScriptSerializer().Deserialize<OrderViewModel>(orderViewModel);
            var orderNew = new Order();
            orderNew.UpdateOrder(order);
            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                orderNew.CustomerId = userId;
                orderNew.CreatedBy = User.Identity.GetUserName();
            }
            //var OrderDetails = new List<OrderDetailViewModel>();
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in order.OrderDetails)
            {
                var detail = new OrderDetail();
                detail.ProductLink = item.ProductLink;
                detail.ProductImage = item.ProductImage;
                detail.ProductDetail = item.ProductDetail;
                detail.Quantity = item.Quantity;
                detail.Description = item.Description;
                orderDetails.Add(detail);
            }
            _orderService.Add(ref orderNew, orderDetails);
            _orderService.SaveChanges();
            return Json(new
            {
                status = true,
            });
        }
        [Authorize]
        public JsonResult GetUserInfo()
        {
            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var user = _userManager.FindById(userId);
                return Json(new
                {
                    data = user,
                    status = true
                });
            }
            return Json(new
            {
                status = false,
                message = "Bạn cần đăng nhập để sử dụng tính năng này!!!"
            });
        }
    }
}