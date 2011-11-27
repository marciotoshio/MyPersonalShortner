using System.Web.Mvc;
using Facebook.Web;
using MyPersonalShortner.Lib.Services;
using MyPersonalShortner.MvcApp.Helpers;

namespace MyPersonalShortner.MvcApp.Controllers
{
    public class AccountController : Controller
    {
        private IFacebookUserService service;
        public AccountController(IFacebookUserService service)
        {
            this.service = service;
        }

        public ActionResult Login()
        {
            var currentUser = FacebookHelper.CurrentUser(service);
            return PartialView(currentUser);
        }
    }
}
