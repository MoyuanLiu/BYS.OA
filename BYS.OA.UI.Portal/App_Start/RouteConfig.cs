﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BYS.OA.UI.Portal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "UserLogin", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "匹配所有的url",
                url: "{*Catch所有的请求}",
                defaults: new { controller = "OrderInfo", action = "Index" }
            );
        }
    }
}