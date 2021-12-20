using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TNS.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            //admin
            routes.MapRoute(
               name: "admin",
               url: "admin.html",
               defaults: new { controller = "Admin", action = "Index", tagId = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );

            //user
            routes.MapRoute(
               name: "User Index",
               url: "Dashboard",
               defaults: new { controller = "Home", action = "UserIndex", tagId = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //Add order Client 
            routes.MapRoute(
               name: "Add Order",
               url: "orders/add-order",
               defaults: new { controller = "Order", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //listorder Client
            routes.MapRoute(
               name: "ListOrder",
               url: "orders",
               defaults: new { controller = "ShoppingCart", action = "ListOrder", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //No order cart 
            routes.MapRoute(
               name: "No order",
               url: "no-order.html",
               defaults: new { controller = "Live", action = "NoOrder", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //checkout completed 
            routes.MapRoute(
               name: "Checkout completed",
               url: "trang-thai-don-hang",
               defaults: new { controller = "Order", action = "CheckOutSuccess", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            routes.MapRoute(
               name: "Confirm Order",
               url: "xac-nhan-don-hang.html",
               defaults: new { controller = "ShoppingCart", action = "ConfirmOrder", id = UrlParameter.Optional },
               namespaces: new string[] { "TeduShop.Web.Controllers" }
              );
            routes.MapRoute(
               name: "Cancel Order",
               url: "huy-don-hang.html",
               defaults: new { controller = "ShoppingCart", action = "CancelOrder", id = UrlParameter.Optional },
               namespaces: new string[] { "TeduShop.Web.Controllers" }
              );
            //contact
            routes.MapRoute(
               name: "Contact",
               url: "contact.html",
               defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //ExternalLoginCallback
            routes.MapRoute(
               name: "ExternalLoginCallback",
               url: "xac-thuc-tai-khoan.html",
               defaults: new { controller = "Account", action = "ExternalLoginCallback", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            routes.MapRoute(
              name: "Register",
              url: "dang-ky.html",
              defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
              namespaces: new string[] { "TNS.Web.Controllers" }
          );
            routes.MapRoute(
              name: "Manage",
              url: "tai-khoan.html",
              defaults: new { controller = "Manage", action = "Index", id = UrlParameter.Optional },
              namespaces: new string[] { "TNS.Web.Controllers" }
          );
            routes.MapRoute(
              name: "ChangePassword",
              url: "thay-doi-mat-khau.html",
              defaults: new { controller = "Manage", action = "ChangePassword", id = UrlParameter.Optional },
              namespaces: new string[] { "TNS.Web.Controllers" }
          );
            routes.MapRoute(
             name: "SetPassword",
             url: "dat-lai-mat-khau.html",
             defaults: new { controller = "Manage", action = "SetPassword", id = UrlParameter.Optional },
             namespaces: new string[] { "TNS.Web.Controllers" }
         );
            routes.MapRoute(
            name: "ConfirmEmail",
            url: "kich-hoat-thanh-cong.html",
            defaults: new { controller = "Account", action = "ConfirmEmail", id = UrlParameter.Optional },
            namespaces: new string[] { "TNS.Web.Controllers" }
        );
            routes.MapRoute(
            name: "ForgotPassword",
            url: "quen-mat-khau.html",
            defaults: new { controller = "Account", action = "ForgotPassword", id = UrlParameter.Optional },
            namespaces: new string[] { "TNS.Web.Controllers" }
        );
            routes.MapRoute(
            name: "ForgotPasswordConfirmation",
            url: "xac-nhan-mat-khau.html",
            defaults: new { controller = "Account", action = "ForgotPasswordConfirmation", id = UrlParameter.Optional },
            namespaces: new string[] { "TNS.Web.Controllers" }
        );
            //live
            routes.MapRoute(
               name: "Live",
               url: "vi-tri-truc-tuyen.html",
               defaults: new { controller = "Live", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //login
            routes.MapRoute(
               name: "Login client",
               url: "dang-nhap.html",
               defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //logout
            routes.MapRoute(
               name: "Logout client",
               url: "logout.html",
               defaults: new { controller = "Account", action = "LogOut", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //introduce
            routes.MapRoute(
               name: "Giới thiệu",
               url: "gioi-thieu.html",
               defaults: new { controller = "Home", action = "Introduce", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //bảng giá
            routes.MapRoute(
               name: "Bảng giá",
               url: "bang-gia.html",
               defaults: new { controller = "Home", action = "PriceTable", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //Hướng dẫn
            routes.MapRoute(
               name: "Hướng dẫn",
               url: "huong-dan.html",
               defaults: new { controller = "Home", action = "Guide", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //Chính sách
            routes.MapRoute(
               name: "Chính sách",
               url: "chinh-sach.html",
               defaults: new { controller = "Home", action = "Policy", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //Tuyển dụng
            routes.MapRoute(
               name: "Tuyển dụng",
               url: "tuyen-dung.html",
               defaults: new { controller = "Home", action = "Recruitment", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //Liên hệ
            routes.MapRoute(
               name: "Liên hệ",
               url: "lien-he.html",
               defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "TNS.Web.Controllers" }
            );

        }
    }
}
