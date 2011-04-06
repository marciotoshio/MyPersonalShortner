using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPersonalShortner.MvcApp.Controllers
{
    public class ShortnerController : Controller
    {
        //
        // GET: /Shortner/

        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectPermanent(id);   
            }
        }

    }
}
