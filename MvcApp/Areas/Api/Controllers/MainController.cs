using System;
using System.Web.Mvc;
using MyPersonalShortner.Lib.Services;
using MyPersonalShortner.MvcApp.Areas.Api.DTO;
using MyPersonalShortner.Lib.CustomExceptions;

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
            return Json(new { Welcome = "Welcome API v0.1!!!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Shorten()
        {
            try
            {
                var url = Request["url"];
                var hash = service.Shorten(url.Trim());
                var result = new ApiShortenResult
                {
                    Success = true,
                    Message = "success",
                    Hash = hash,
                    LongUrl = url
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ShortnerValidationException ex)
            {
                var validationResult = new ApiErrorResult { 
                    Success = false,
                    Errors = ex.Errors,
                    Message = ex.Message
                };
                Response.StatusCode = 500;
                Response.TrySkipIisCustomErrors = true;
                return Json(validationResult);
            }
            catch (Exception ex)
            {
                var exResult = new ApiResult {
                    Success = false,
                    Message = ex.Message
                };
                Response.StatusCode = 500;
                Response.TrySkipIisCustomErrors = true;
                return Json(exResult);
            }
        }
    }
}
