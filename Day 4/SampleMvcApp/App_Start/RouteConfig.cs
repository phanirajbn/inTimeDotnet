using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SampleMvcApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Home",
                url: "Home/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Calc",
                url: "Calc/{action}/{id}",
                defaults: new { controller = "Calc", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Hotel",
                url: "Hotel/{action}",
                defaults: new { controller = "Hotel", action = "Register" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Hotel", action = "Home" }
            );
        }
    }
}
