using System.Runtime.Serialization;

namespace MyPersonalShortner.MvcApp.Areas.Api.DTO
{
    [DataContract(Name = "data")]
    public class ApiShortenResult : ApiResult
    {
        // TODO: remove hard-coded domain
        [DataMember(Name = "url")]
        public string Url { get { return "http://tosh.io/" + Hash; } }

        [DataMember(Name = "hash")]
        public string Hash { get; set; }

        [DataMember(Name = "longUrl")]
        public string LongUrl { get; set; }
    }
}
