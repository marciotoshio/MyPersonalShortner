using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPersonalShortner.MvcApp.Helpers
{
    public class AppHelper
    {
        public static string GetFullHostAddress()
        {
            return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/";
        }
    }
}