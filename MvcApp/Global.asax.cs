using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using MyPersonalShortner.Lib.Services;
using MyPersonalShortner.MvcApp.IoC;
using MyPersonalShortner.Lib.Domain.Repositories;
using MyPersonalShortner.Lib.Infrastructure.EntityFramework.DataAccess;
using MyPersonalShortner.Lib.Domain.UrlConversion;
using MyPersonalShortner.Lib.Domain.Twitter;
using MyPersonalShortner.Lib.Infrastructure.TweetSharp;

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

            DependencyResolver.SetResolver(new UnityDependencyResolver(GetUnityContainer()));
        }

        private static string CharsForHash
        {
            get { return "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
        }

        private static IUnityContainer GetUnityContainer()
        {
            //Create UnityContainer          
            var container = new UnityContainer()
            .RegisterType<IControllerActivator, CustomControllerActivator>()
            .RegisterType<IShortnerService, ShortnerService>(new HttpContextLifetimeManager<IShortnerService>())
            .RegisterType<ILongUrlRepository, LongUrlDataAccess>(new HttpContextLifetimeManager<ILongUrlRepository>())
            .RegisterType<ICustomUrlRepository, CustomUrlDataAccess>(new HttpContextLifetimeManager<ICustomUrlRepository>())
            .RegisterType<IUrlConversion, Base10ToHash>(new HttpContextLifetimeManager<IUrlConversion>(), new InjectionConstructor(CharsForHash))
            .RegisterType<ITwitterService, TwitterService>(new HttpContextLifetimeManager<ITwitterService>())
            .RegisterType<ITwitter, TweetSharpImpl>(new InjectionConstructor("5CodmDJ548luW9gkrH0sg", "bnNNQ17QBLMcQ9g5Tosbbr3ps2BHtTE8AvtKZgTmdCM"))
            .RegisterType <IFacebookUserService, FacebookUserService>(new HttpContextLifetimeManager<IFacebookUserService>())
            .RegisterType<IFacebookUserRepository, FacebookUserDataAccess>(new HttpContextLifetimeManager<IFacebookUserRepository>());

            return container;
        }
    }
}