using System.Web.Mvc;
using Facebook.Web;
using MyPersonalShortner.Lib.Services;
using MyPersonalShortner.MvcApp.Helpers;

namespace MyPersonalShortner.MvcApp.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            var currentUser = FacebookHelper.CurrentUser();
            return PartialView(currentUser);
        }
    }
}
