using System.Web.Mvc;

namespace MyPersonalShortner.ShortnerApp.Controllers
{
	public class HomeController : Controller
	{
		//
		// GET: /Home/

		public ActionResult Index()
		{
			return View();
		}

	}
}
