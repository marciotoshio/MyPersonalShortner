using MyPersonalShortner.Lib.Domain.Twitter;

namespace MyPersonalShortner.MvcApp.Areas.Api.Models
{
    public class ApiTwitterResult : ApiResult
    {
        public AccessToken AccessToken { get; set; }
        public string ScreenName { get; set; }
    }
}
