﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPersonalShortner.Lib.Services;

namespace MyPersonalShortner.MvcApp.Controllers
{
    public class ShortnerController : Controller
    {
        private IShortnerService service;
        public ShortnerController(IShortnerService service)
        {
            this.service = service;
        }

        //
        // GET: /Shortner/
        public ActionResult Index(string hash)
        {
            if (string.IsNullOrEmpty(hash))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var url = service.Expand(hash);
                return RedirectPermanent(url);   
            }
        }
    }
}
