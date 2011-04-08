using System.Web.Mvc;

namespace MyPersonalShortner.MvcApp.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Api",
                "Api/{action}",
                new { controller = "Main", action = "Index" }
            );
        }
    }
}
