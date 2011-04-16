using System;
using System.Web.Mvc;
using MyPersonalShortner.Lib.Domain.Twitter;
using MyPersonalShortner.Lib.Services;
using MyPersonalShortner.MvcApp.Areas.Api.DTO;
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
            try
            {
                callbackUrl = AppHelper.GetFullHostAddress() + callbackUrl;
                var uri = twitterService.Authorize(callbackUrl);
                return new RedirectResult(uri, false /*permanent*/);
            }
            catch (Exception ex)
            {
                return Content("Error on authenticate: " + ex.Message);
            }
            
        }

        public JsonResult Authenticate()
        {
            ApiResult result;
            try
            {
                var oauthToken = Request["oauth_token"];
                var oauthVerifier = Request["oauth_verifier"];
                var accessToken = twitterService.Authenticate(oauthToken, oauthVerifier);
                var screenName = twitterService.GetScreenName(accessToken);
                result = new ApiTwitterResult {
                                AccessToken = accessToken, 
                                ScreenName = screenName, 
                                Message = "ok", 
                                Success = true
                };
                return Json(result, "application/json", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                result = new ApiResult
                {
                    Success = false,
                    Message = ex.Message
                };
                ResponseError();
            }
            return Json(result, "application/json", JsonRequestBehavior.AllowGet);            
        }

        [HttpPost]
        public JsonResult UpdateStatus(string token, string tokenSecret, string status)
        {
            ApiResult result;
            try
            {
                var accessToken = new AccessToken {Token = token, TokenSecret = tokenSecret};
                twitterService.UpdateStatus(accessToken, status);
                result = new ApiResult {Message = "ok", Success = true};
            }
            catch (Exception ex)
            {
                result = new ApiResult
                {
                    Success = false,
                    Message = ex.Message
                };
                ResponseError();
            }
            return Json(result, "application/json", JsonRequestBehavior.AllowGet); 
        }

        private void ResponseError()
        {
            Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;
        }
    }
}
