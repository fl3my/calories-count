﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaloriesCount
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "FoodsCreate",
                url: "Foods/Create",
                defaults: new { controller = "Foods", action = "create" }
            );

            routes.MapRoute(
                name: "FoodsbyCategorybyPage",
                url: "Foods/{category}/Page{page}",
                defaults: new { controller = "Foods", action = "Index" }
            );

            routes.MapRoute(
                name: "FoodsbyPage",
                url: "Foods/Page{page}",
                defaults: new { controller = "Foods", action = "Index" }
            );

            routes.MapRoute(
                name: "FoodsbyCategory",
                url: "Foods/{category}",
                defaults: new { controller = "Foods", action = "Index" }
            );

            routes.MapRoute(
                name: "FoodsIndex",
                url: "Foods",
                defaults: new { controller = "Foods", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "SplashScreen", id = UrlParameter.Optional }
            );
        }
    }
}
