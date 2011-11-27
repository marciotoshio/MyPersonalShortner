using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook.Web.Mvc;
using MyPersonalShortner.MvcApp.Helpers;
using MyPersonalShortner.Lib.Services;

namespace MyPersonalShortner.MvcApp.Controllers
{
    [FacebookAuthorize(LoginUrl="/")]
    public class CustomUrlController : Controller
    {
        private IFacebookUserService service;
        public CustomUrlController(IFacebookUserService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            var currentUser = FacebookHelper.CurrentUser(service);
            return View(currentUser.CustomUrls);
        }

        //
        // GET: /CustomUrl/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CustomUrl/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /CustomUrl/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /CustomUrl/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CustomUrl/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CustomUrl/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CustomUrl/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
