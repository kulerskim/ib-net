using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ib_dotnet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Topic replies", 
                url: "Topic/{topicId}/Reply/{action}/{id}",
                defaults: new { controller = "Reply", action = "Index", id = UrlParameter.Optional}
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Topic", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}