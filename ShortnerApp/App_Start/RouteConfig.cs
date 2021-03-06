﻿using System.Web.Mvc;
using System.Web.Routing;

namespace MyPersonalShortner.ShortnerApp
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute("Home", "", new { controller = "Home", action = "Index" });
			routes.MapRoute("Shortner", "{hash}", new { controller = "Shortner", action = "Index", hash = UrlParameter.Optional });

			routes.MapRoute(
					name: "Default",
					url: "{controller}/{action}/{id}",
					defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}