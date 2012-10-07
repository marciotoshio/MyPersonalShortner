using System.Web.Mvc;

namespace MvcApp.Areas.CustomUrlAdmin
{
    public class CustomUrlAdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CustomUrlAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CustomUrlAdmin_default",
                "Admin/CustomUrl/{action}/{id}",
                new { controller = "CustomUrl", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
