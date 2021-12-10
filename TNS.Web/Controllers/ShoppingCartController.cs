using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ShoppingCartController : Controller
    {
        /*        private IOrderService _orderService;
                private ApplicationUserManager _userManager;*/

        /*        public ShoppingCartController(ApplicationUserManager userManager, IOrderService orderService)
                {
                    _userManager = userManager;
                    _orderService = orderService;
                }*/
        // GET: ShoppingCart
        public ActionResult Index()
        {
            if (Session[CommonConstants.ShoppingCartSession] == null)
                Session[CommonConstants.ShoppingCartSession] = new List<ShoppingCartViewModel>();
            return View();
        }

        [HttpPost]
        public JsonResult Add(OrderDetailViewModel orderdetailVm)
        {
            var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.ShoppingCartSession];
            if (cart == null)
            {
                cart = new List<ShoppingCartViewModel>();
            }
            else
            {
                ShoppingCartViewModel newItem = new ShoppingCartViewModel();
                newItem.ProductLink = orderdetailVm.ProductLink;
                newItem.ProductImage = orderdetailVm.ProductImage;
                newItem.ProductDetail = orderdetailVm.ProductDetail;
                newItem.Quantity = orderdetailVm.Quantity;
                newItem.Description = orderdetailVm.Description;
                cart.Add(newItem);
            }
            Session[CommonConstants.ShoppingCartSession] = cart;
            return Json(new
            {
                status = true
            });
        }

        /*        [HttpPost]
                public ActionResult CreateOrder(string orderViewModel)
                {
                    if (!Request.IsAuthenticated)
                    {
                        TempData["UnAuthenticated"] = "Bạn phải đăng nhập để thanh toán";
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
                    var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.ShoppingCartSession];
                    List<OrderDetail> orderDetails = new List<OrderDetail>();
                    foreach (var item in cart)
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
                    return Json(new
                    {
                        status = true,
                    });
                }*/
        public ActionResult ListOrder()
        {
            return View();
        }
    }
}