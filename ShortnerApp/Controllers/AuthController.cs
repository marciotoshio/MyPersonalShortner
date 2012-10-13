using MyPersonalShortner.ShortnerApp.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPersonalShortner.ShortnerApp.Controllers
{
	public class AuthController : Controller
	{
		public ActionResult Login()
		{
			return View(new User());
		}

		[HttpPost]
		public ActionResult Login(User user, string returnUrl)
		{
			if (FormsAuthentication.Authenticate(user.UserName, user.Password))
			{
				FormsAuthentication.SetAuthCookie(user.UserName, false);
				return Redirect(returnUrl);
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
