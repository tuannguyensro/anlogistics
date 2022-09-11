using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TNS.Common;
using TNS.Common.ViewModels;
using TNS.Model.Models;
using TNS.Service;
using TNS.Web.App_Start;
using TNS.Web.Infrastructure.Core;
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
        public ActionResult CreateOrder(string orderViewModel, HttpPostedFileBase ProductImage)
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
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in order.OrderDetails)
            {
                var detail = new OrderDetail(); 
                    detail.ID = item.ID;
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

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if(file != null)
            {
                string _FileName = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/UploadedFiles/ProductImage/"), _FileName);
                file.SaveAs(path);                
            }
            return "/UploadedFiles/ProductImage/" + file.FileName;
        }

        public JsonResult GetAll()
        {
            if (Session[CommonConstants.ShoppingCartSession] == null)
            {
                Session[CommonConstants.ShoppingCartSession] = new List<ShoppingCartViewModel>();
            }
            var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.ShoppingCartSession];

            return Json(new
            {
                status = true,
                data = cart
            }, JsonRequestBehavior.AllowGet);
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

        [Authorize]
        public ActionResult ListOrder(int page = 1, int pageSize = 5)
        {
            //int pageSize = int.Parse(ConfigHelper.GetByKey("pageSize"));
            int totalRow = 0;
            var userId = User.Identity.GetUserId();
            var orders = _orderService.GetListOrders(userId, page, pageSize, out totalRow);
            var orderVm = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderClientViewModel>>(orders);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var paginationSet = new PaginationSet<OrderClientViewModel>()
            {
                Items = orderVm,
                MaxPage = int.Parse(ConfigHelper.GetByKey("maxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            return View(paginationSet);
        }

/*        [Authorize]
        public JsonResult GetListOrder()
        {
            var userId = User.Identity.GetUserId();
            var orders = _orderService.GetListOrders(User.Identity.GetUserId());

            return Json(new
            {
                data = orders,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }*/

        [Authorize]
        public ActionResult ListOrderDetailByID(int id)
        {
            var orderdetail = _orderService.ListDetailByOrderID(id);
            var orderdetailVm = Mapper.Map<IEnumerable<OrderDetail>, IEnumerable<OrderDetailViewModel>>(orderdetail);           
            var order = _orderService.FindById(id);
            var orderVm = Mapper.Map<Order, OrderViewModel>(order);
            ViewBag.Order = orderVm;
            return View(orderdetailVm);
        }
    }
}