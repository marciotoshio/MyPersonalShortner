using System;
using System.Configuration;
using System.Web;

namespace MyPersonalShortner.MvcApp.Helpers
{
    public class AppHelper
    {
        public static string AppName
        {
            get { return ConfigurationManager.AppSettings["AppName"]; }
        }

        public static string TwitterConsumerKey
        {
            get { return ConfigurationManager.AppSettings["TwitterConsumerKey"]; }
        }

        public static string TwitterConsumerSecret
        {
            get { return ConfigurationManager.AppSettings["TwitterConsumerSecret"]; }
        }

        public static string GoogleAnalyticsCode
        {
            get { return ConfigurationManager.AppSettings["GACode"]; }
        }

        public static string CharsForHash
        {
            get { return "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
        }

        public static string GetFullHostAddress()
        {
            return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority;
        }

        public static void EnableCors(HttpContext context)
        {
            SetAllowCrossSiteRequestMethod(context);
            SetAllowCrossSiteRequestHeaders(context);
            SetAllowCrossSiteRequestOrigin(context);
        }

        private static void SetAllowCrossSiteRequestMethod(HttpContext context)
        {
            var method = context.Request.Headers["Access-Control-Request-Method"];
            if (!String.IsNullOrEmpty(method) && (method.ToUpper() == "GET"))
                context.Response.AppendHeader("Access-Control-Allow-Methods", "GET");
        }

        private static void SetAllowCrossSiteRequestHeaders(HttpContext context)
        {
            var headers = context.Request.Headers["Access-Control-Request-Headers"];
            if (!String.IsNullOrEmpty(headers))
                context.Response.AppendHeader("Access-Control-Allow-Headers", headers);
        }

        private static void SetAllowCrossSiteRequestOrigin(HttpContext context)
        {
            var origin = context.Request.Headers["Origin"];
            context.Response.AppendHeader("Access-Control-Allow-Origin", String.IsNullOrEmpty(origin) ? "*" : origin);
        }
    }
}