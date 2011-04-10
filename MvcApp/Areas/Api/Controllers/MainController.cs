using System;
using System.Web.Mvc;
using MyPersonalShortner.Lib.Services;
using MyPersonalShortner.MvcApp.Areas.Api.DTO;
using MyPersonalShortner.Lib.CustomExceptions;
using MyPersonalShortner.MvcApp.Helpers;

namespace MyPersonalShortner.MvcApp.Areas.Api.Controllers
{
    public class MainController : Controller
    {
        private readonly IShortnerService service;
        public MainController(IShortnerService service)
        {
            this.service = service;
        }

        public JsonResult Index()
        {
            AppHelper.EnableCors(System.Web.HttpContext.Current);
            return Json(new { Welcome = "Welcome, My Personal Shorner API v0.1!!!" }, "application/json");
        }

        [HttpPost]
        public JsonResult Shorten()
        {
            ApiResult result;
            try
            {
                var url = Request["url"];
                var hash = service.Shorten(url.Trim());
                result = new ApiShortenResult
                {
                    Success = true,
                    Message = "success",
                    Hash = hash,
                    LongUrl = url
                };
            }
            catch (ShortnerValidationException ex)
            {
                result = new ApiErrorResult { 
                    Success = false,
                    Errors = ex.Errors,
                    Message = ex.Message
                };
                ResponseError();
            }
            catch (Exception ex)
            {
                result = new ApiResult {
                    Success = false,
                    Message = ex.Message
                };
                ResponseError();
            }
            AppHelper.EnableCors(System.Web.HttpContext.Current);
            return Json(result, "application/json");
        }

        private void ResponseError()
        {
            Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;
        }
    }
}
