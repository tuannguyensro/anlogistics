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
            //products by tag
            routes.MapRoute(
               name: "Products by tag",
               url: "products/tags-{tagId}.html",
               defaults: new { controller = "Product", action = "ProductsByTag", tagId = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );

            routes.MapRoute(
                name: "Product category",
                url: "category/{alias}-{id}.html",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new string[] { "TNS.Web.Controllers" }
            );
            //Detail
            routes.MapRoute(
                name: "Product Detail",
                url: "product/{alias}-{id}.html",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new string[] { "TNS.Web.Controllers" }
            );
            //search
            routes.MapRoute(
               name: "Search",
               url: "search.html",
               defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //shop
            routes.MapRoute(
               name: "Shop",
               url: "shop.html",
               defaults: new { controller = "Product", action = "Shop", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //page
            routes.MapRoute(
               name: "Page",
               url: "trang-{alias}.html",
               defaults: new { controller = "Page", action = "Index", alias = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //wishlist
            routes.MapRoute(
               name: "wishlist",
               url: "san-pham-yeu-thich.html",
               defaults: new { controller = "Wishlist", action = "Index", alias = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //User Index
            routes.MapRoute(
               name: "User Admin",
               url: "quan-ly-he-thong.html",
               defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "TNS.Web.Controllers" }
           );
            //shopping cart 
            routes.MapRoute(
               name: "Shopping cart",
               url: "tao-don-hang.html",
               defaults: new { controller = "ShoppingCart", action = "Index", id = UrlParameter.Optional },
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
