using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhuocCon.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });
            // ContactController
            routes.MapRoute(
             name: "Contact",
             url: "lien-he.html",
             defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
             namespaces: new string[] { "PhuocCon.Web.Controllers" }

         );
            // ShoppingCartController
            routes.MapRoute(
                name: "Checkout",
                url: "thanh-toan.html",
                defaults: new { controller = "ShoppingCart", action = "CheckOut", id = UrlParameter.Optional },
                namespaces: new string[] { "PhuocCon.Web.Controllers" }

            );
            routes.MapRoute(
            name: "ShoppingCart",
            url: "gio-hang.html",
            defaults: new { controller = "ShoppingCart", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "PhuocCon.Web.Controllers" }

        );
            routes.MapRoute(
            name: "Confirm Order",
            url: "xac-nhan-don-hang.html",
            defaults: new { controller = "ShoppingCart", action = "ConfirmOrder", id = UrlParameter.Optional },
            namespaces: new string[] { "PhuocCon.Web.Controllers" }

        );
            routes.MapRoute(
            name: "Cancel Order",
            url: "huy-don-hang.html",
            defaults: new { controller = "ShoppingCart", action = "CancelOrder", id = UrlParameter.Optional },
            namespaces: new string[] { "PhuocCon.Web.Controllers" }

        );
            // ProductController
            routes.MapRoute(
             name: "Search",
             url: "tim-kiem.html",
             defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
             namespaces: new string[] { "PhuocCon.Web.Controllers" }

         );
            routes.MapRoute(
            name: "Product Category",
            url: "{alias}.pc-{id}.html",
            defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
            namespaces: new string[] { "PhuocCon.Web.Controllers" }
        );
            routes.MapRoute(
               name: "Product",
               url: "{alias}.p-{productId}.html",
               defaults: new { controller = "Product", action = "Detail", productId = UrlParameter.Optional },
               namespaces: new string[] { "PhuocCon.Web.Controllers" }
           );
            routes.MapRoute(
              name: "TagList",
              url: "tag/{tagid}.html",
              defaults: new { controller = "Product", action = "ListByTag", tagid = UrlParameter.Optional },
              namespaces: new string[] { "PhuocCon.Web.Controllers" }
          );
            // AccountController
            routes.MapRoute(
              name: "Login",
              url: "dang-nhap.html",
              defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
              namespaces: new string[] { "PhuocCon.Web.Controllers" }

          );
            routes.MapRoute(
              name: "ForgotPassword",
              url: "quen-mat-khau.html",
              defaults: new { controller = "Account", action = "ForgotPassword", id = UrlParameter.Optional },
              namespaces: new string[] { "PhuocCon.Web.Controllers" }

          );
            routes.MapRoute(
             name: "Register",
             url: "dang-ky.html",
             defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
             namespaces: new string[] { "PhuocCon.Web.Controllers" }

         );
            // ManageController 
            routes.MapRoute(
              name: "Index",
              url: "tai-khoan.html",
              defaults: new { controller = "Manage", action = "Index", id = UrlParameter.Optional },
              namespaces: new string[] { "PhuocCon.Web.Controllers" }

            );
            routes.MapRoute(
              name: "ChangePassword",
              url: "thay-doi-mat-khau.html",
              defaults: new { controller = "Manage", action = "ChangePassword", id = UrlParameter.Optional },
              namespaces: new string[] { "PhuocCon.Web.Controllers" }
            );
            routes.MapRoute(
             name: "ChangeAccount",
             url: "thay-doi-thong-tin/{username}.html",
             defaults: new { controller = "Manage", action = "UpdateUser", username = UrlParameter.Optional },
             namespaces: new string[] { "PhuocCon.Web.Controllers" }
           );
            // AboutController
            routes.MapRoute(
               name: "Page",
               url: "trang/{alias}.html",
               defaults: new { controller = "About", action = "Index", alias = UrlParameter.Optional },
               namespaces:new string[] { "PhuocCon.Web.Controllers"}
               
           );
            //HomeController
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PhuocCon.Web.Controllers" }
            );
        }
    }
}
