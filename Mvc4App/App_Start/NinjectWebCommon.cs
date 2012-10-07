[assembly: WebActivator.PreApplicationStartMethod(typeof(MvcApp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(MvcApp.App_Start.NinjectWebCommon), "Stop")]

namespace MvcApp.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using MyPersonalShortner.Lib.Services;
    using MyPersonalShortner.Lib.Domain.Repositories;
    using MyPersonalShortner.Lib.Domain.UrlConversion;
    using MyPersonalShortner.Lib.Infrastructure.EntityFramework.DataAccess;
    using MyPersonalShortner.Lib.Domain.Twitter;
    using MyPersonalShortner.Lib.Infrastructure.TweetSharp;
    using MyPersonalShortner.MvcApp.Helpers;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IShortnerService>().To<ShortnerService>();
            kernel.Bind<ILongUrlRepository>().To<LongUrlDataAccess>();
            kernel.Bind<ICustomUrlRepository>().To<CustomUrlDataAccess>();
            kernel.Bind<IUrlConversion>().To<Base10ToHash>().WithConstructorArgument("chars", AppHelper.CharsForHash);
            kernel.Bind<ITwitterService>().To<TwitterService>();
            kernel.Bind<ITwitter>().To<TweetSharpImpl>().WithConstructorArgument("consumerKey", AppHelper.TwitterConsumerKey).WithConstructorArgument("consumerSecret", AppHelper.TwitterConsumerSecret);
        }        
    }
}
