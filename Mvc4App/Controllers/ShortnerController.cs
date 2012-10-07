using System;
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
            try
            {
                var url = service.Expand(hash);
                return RedirectPermanent(url);
            }
            catch (ArgumentOutOfRangeException)
            {
                return RedirectToAction("UrlNotFound");
            }
        }

        public ActionResult UrlNotFound()
        {
            return View();
        }
    }
}
