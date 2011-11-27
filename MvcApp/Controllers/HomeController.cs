using System.Web.Mvc;

namespace MyPersonalShortner.MvcApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}