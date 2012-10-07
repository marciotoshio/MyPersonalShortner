using System.Runtime.Serialization;

namespace MyPersonalShortner.MvcApp.Areas.Api.DTO
{
    public class ApiResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}