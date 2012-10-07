using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPersonalShortner.MvcApp.Controllers
{
    public class AuthController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if(FormsAuthentication.Authenticate(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return Redirect("/Admin/CustomUrl/");
            }
            return View();
        }

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
