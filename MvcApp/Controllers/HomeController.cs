using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPersonalShortner.Lib.Services;

namespace MyPersonalShortner.MvcApp.Controllers
{
    public class HomeController : Controller
    {
        private IShortnerService service;
        public HomeController(IShortnerService service)
        {
            this.service = service;
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formsCollection)
        {
            var url = formsCollection["url"];
            var longUrl = this.service.Add(url);
            ViewBag.ShortenUrl = this.service.Shorten(longUrl.Id);
            return View();
        }
    }
}
