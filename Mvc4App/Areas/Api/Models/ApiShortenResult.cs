using MyPersonalShortner.MvcApp.Helpers;

namespace MyPersonalShortner.MvcApp.Areas.Api.Models
{
    public class ApiShortenResult : ApiResult
    {
        public string Url { get { return string.Format("{0}/{1}", AppHelper.GetFullHostAddress(), Hash); } }
        public string Hash { get; set; }
        public string LongUrl { get; set; }
    }
}
