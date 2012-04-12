using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MyPersonalShortner.Lib.Services;
using MyPersonalShortner.Lib.Domain.Repositories;
using MyPersonalShortner.Lib.Infrastructure.EntityFramework.DataAccess;
using MyPersonalShortner.Lib.Domain.UrlConversion;
using MyPersonalShortner.Lib.Domain.Twitter;
using MyPersonalShortner.Lib.Infrastructure.TweetSharp;
using MyPersonalShortner.Lib.Infrastructure.EntityFramework;
using MyPersonalShortner.Lib.Infrastructure;
using MyPersonalShortner.MvcApp.Helpers;

namespace MyPersonalShortner.MvcApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Home", "", new { controller = "Home", action = "Index" });
            routes.MapRoute("UserCustomUrls", "user/customurls/{action}/{id}", new { controller = "CustomUrl", action = "Index", id = UrlParameter.Optional });
            routes.MapRoute("Shortner", "{hash}", new { controller = "Shortner", action = "Index", hash = UrlParameter.Optional });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Shortner", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        // ReSharper disable InconsistentNaming
        protected void Application_Start()
        // ReSharper restore InconsistentNaming
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }        
    }
}