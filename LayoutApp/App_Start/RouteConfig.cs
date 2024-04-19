using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LayoutApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Tạo map route thủ công
            //Lưu ý: MapRoute đọc từ trên xuống nếu trùng thì nhập MapRoute đó.
            //routes.MapRoute(
            //    name: "Product",
            //    url: "{Products}/{GetProductId}/{name}",
            //    defaults: new { controller = "Products", action = "getProductId" }
            //);

            //Tạo Attribute Route nhận dạng MapRoute đã dc tạo ở trong Controller.
            //Lưu ý: MapRoute đọc từ trên xuống nếu trùng thì nhập MapRoute đó.
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
