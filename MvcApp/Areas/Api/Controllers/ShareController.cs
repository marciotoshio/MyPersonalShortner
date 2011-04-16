using System;
using System.Web.Mvc;
using MyPersonalShortner.Lib.Services;
using MyPersonalShortner.MvcApp.Areas.Api.DTO;
using MyPersonalShortner.Lib.CustomExceptions;
using MyPersonalShortner.MvcApp.Helpers;

namespace MyPersonalShortner.MvcApp.Areas.Api.Controllers
{
    public class ShareController : Controller
    {
        private readonly ITwitterService twitterService;
        public ShareController(ITwitterService twitterService)
        {
            AppHelper.EnableCors(System.Web.HttpContext.Current);
            this.twitterService = twitterService;
        }

        public ActionResult Authorize(string callbackUrl)
        {
            callbackUrl = AppHelper.GetFullHostAddress() + callbackUrl;
            var uri = twitterService.Authorize(callbackUrl);
            return new RedirectResult(uri, false /*permanent*/);
        }

        public JsonResult Authenticate(string oauth_token, string oauth_verifier)
        {
            var accessToken = twitterService.Authenticate(oauth_token, oauth_verifier);
            var screenName = twitterService.GetScreenName(accessToken);
            return Json(new ApiTwitterResult { AccessToken = accessToken, ScreenName = screenName, Message = "ok", Success = true }, 
                "application/json", JsonRequestBehavior.AllowGet);
        }
    }
}
