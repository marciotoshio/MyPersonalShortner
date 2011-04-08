using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPersonalShortner.Lib.Services;
using MyPersonalShortner.MvcApp.Areas.Api.DTO;

namespace MyPersonalShortner.MvcApp.Areas.Api.Controllers
{
    public class MainController : Controller
    {
        private IShortnerService service;
        public MainController(IShortnerService service)
        {
            this.service = service;
        }

        public JsonResult Index()
        {
            return Json(new { Welcome = "Welcome API v0.1!!!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Shorten()
        {
            var url = Request["url"];
            var hash = this.service.Shorten(url);
            
            return Json(new ApiShortenResult
            {
                Success = true,
                Hash = hash,
                LongUrl = url
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
