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
            //shopping cart 
            routes.MapRoute(
               name: "Shopping cart",
               url: "orders/add-order",
               defaults: new { controller = "ShoppingCart", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //listorder shopping cart 
            routes.MapRoute(
               name: "ListOrder Shopping cart",
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
               url: "xem-trang-thai-mat-hang.html",
               defaults: new { controller = "ShoppingCart", action = "CheckOutSuccess", id = UrlParameter.Optional },
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
            routes.MapRoute(
    name: "Default",
    url: "{controller}/{action}/{id}",
    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
);
            //admin
            // routes.MapRoute(
            //    name: "admin",
            //    url: "admin.htmll",
            //    defaults: new { controller = "Admin", action = "Index", tagId = UrlParameter.Optional },
            //    namespaces: new string[] { "TNS.Web.Controllers" }
            //);
        }
    }
}
