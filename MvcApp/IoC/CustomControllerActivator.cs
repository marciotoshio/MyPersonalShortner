using System;
using System.Web.Mvc;

namespace MyPersonalShortner.MvcApp.IoC
{
    public class CustomControllerActivator : IControllerActivator
    {
        IController IControllerActivator.Create(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}