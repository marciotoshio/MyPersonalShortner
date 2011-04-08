using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using System.Web.Mvc;

namespace MyPersonalShortner.MvcApp.IoC
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        IUnityContainer container;
        public UnityDependencyResolver(IUnityContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch(Exception ex)
            {
                var w = new System.IO.StreamWriter(HttpContext.Current.Request.MapPath("~/log/log.txt"));
                w.WriteLine("============== Exception ==============");
                w.WriteLine(string.Format("{0} :: {1} :: {2}", DateTime.Now, ex.Message, ex.StackTrace));
                if (ex.InnerException != null)
                {
                    w.WriteLine("============== InnerException 1 ==============");
                    w.WriteLine(string.Format("{0} :: {1} :: {2}", DateTime.Now, ex.InnerException.Message, ex.InnerException.StackTrace));
                }
                if (ex.InnerException.InnerException != null)
                {
                    w.WriteLine("============== InnerException 2 ==============");
                    w.WriteLine(string.Format("{0} :: {1} :: {2}", DateTime.Now, ex.InnerException.InnerException.Message, ex.InnerException.InnerException.StackTrace));
                }
                w.Close();
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch
            {
                return new List<object>();
            }
        }
    }
}