using System.Collections.Generic;

namespace MyPersonalShortner.MvcApp.Areas.Api.Models
{
    public class ApiErrorResult : ApiResult
    {
        public List<string> Errors { get; set; }
    }
}