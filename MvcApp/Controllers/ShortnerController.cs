using System.Web.Mvc;
using MyPersonalShortner.Lib.Services;

namespace MyPersonalShortner.MvcApp.Controllers
{
    public class ShortnerController : Controller
    {
        private readonly IShortnerService service;
        public ShortnerController(IShortnerService service)
        {
            this.service = service;
        }

        public ActionResult Index(string hash)
        {
            var url = service.Expand(hash);
            return RedirectPermanent(url);
        }
    }
}
