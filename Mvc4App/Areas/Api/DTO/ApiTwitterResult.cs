using System.Runtime.Serialization;
using MyPersonalShortner.Lib.Domain.Twitter;

namespace MyPersonalShortner.MvcApp.Areas.Api.DTO
{
    public class ApiTwitterResult : ApiResult
    {
        public AccessToken AccessToken { get; set; }
        public string ScreenName { get; set; }
    }
}
