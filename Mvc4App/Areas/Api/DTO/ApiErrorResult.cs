using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyPersonalShortner.MvcApp.Areas.Api.DTO
{
    public class ApiErrorResult : ApiResult
    {
        public List<string> Errors { get; set; }
    }
}