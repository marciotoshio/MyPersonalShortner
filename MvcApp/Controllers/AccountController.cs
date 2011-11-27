using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPersonalShortner.Lib.Services;
using Facebook.Web;
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
            if (FacebookWebContext.Current.IsAuthenticated())
            {
                var currentUser = FacebookHelper.CurrentUser;
                service.VerifyIfIsNewUser(currentUser);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}
