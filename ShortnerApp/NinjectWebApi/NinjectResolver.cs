using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace MyPersonalShortner.ShortnerApp.NinjectWebApi
{
	public class NinjectResolver : NinjectScope, IDependencyResolver
	{
		private IKernel _kernel;
		public NinjectResolver(IKernel kernel)
			: base(kernel)
		{
			_kernel = kernel;
		}
		public IDependencyScope BeginScope()
		{
			return new NinjectScope(_kernel.BeginBlock());
		}
	}
}