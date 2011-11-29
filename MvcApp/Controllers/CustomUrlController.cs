using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook.Web.Mvc;
using MyPersonalShortner.MvcApp.Helpers;
using MyPersonalShortner.Lib.Services;
using MyPersonalShortner.Lib.Domain.Url;

namespace MyPersonalShortner.MvcApp.Controllers
{
    [FacebookAuthorize(LoginUrl="/")]
    public class CustomUrlController : Controller
    {
        private IShortnerService shortnerService;
        public CustomUrlController(IShortnerService shortnerService)
        {
            this.shortnerService = shortnerService;
        }

        public ActionResult Index()
        {
            var currentUser = FacebookHelper.CurrentUser();
            var customUrls = shortnerService.CustomUrlsByFacebookId(currentUser.FacebookId);
            return View(customUrls);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(CustomUrl customUrl)
        {
            try
            {
                var currentUser = FacebookHelper.CurrentUser();
                customUrl.FacebookUserId = currentUser.FacebookId;
                shortnerService.AddCustomUrl(customUrl);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
