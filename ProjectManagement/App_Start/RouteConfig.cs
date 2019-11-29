using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



           // routes.MapRoute(
           //     name: "Default1",
           //     url: "Student/{action}/{id}",
           //     defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional }
           // );
           // routes.MapRoute(
           //    name: "Default2",
           //    url: "Faculty/{action}/{id}",
           //    defaults: new { controller = "Faculty", action = "Index", id = UrlParameter.Optional }
           //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Auth", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
