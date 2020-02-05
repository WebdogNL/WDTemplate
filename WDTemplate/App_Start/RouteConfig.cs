using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WDTemplate
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // To enable route attribute in controllers
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Login",
                url: "Login",
                defaults: new { controller = "Login", action = "Index" }
            );

            routes.MapRoute(
                name: "Logoff",
                url: "Logoff",
                defaults: new { controller = "Login", action = "Logoff" }
            );

            routes.MapRoute(
                name: "Error",
                url: "Error/{status}",
                defaults: new { controller = "Function", action = "Error", status = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Function",
                url: "Function/{action}",
                defaults: new { controller = "Function", action = "Index" }
            );

            routes.MapRoute(
                name: "WebdogAlias",
                url: "{alias}",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Webdog",
                url: "{menu}/{page}/{article}",
                defaults: new { controller = "Home", action = "Index", article = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
