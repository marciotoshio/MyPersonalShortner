using System.Runtime.Serialization;
using MyPersonalShortner.MvcApp.Helpers;

namespace MyPersonalShortner.MvcApp.Areas.Api.DTO
{
    [DataContract(Name = "shorten")]
    public class ApiShortenResult : ApiResult
    {
        [DataMember(Name = "url")]
        public string Url { get { return string.Format("{0}/{1}", AppHelper.GetFullHostAddress(), Hash); } }

        [DataMember(Name = "hash")]
        public string Hash { get; set; }

        [DataMember(Name = "longUrl")]
        public string LongUrl { get; set; }
    }
}
