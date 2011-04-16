using System.Runtime.Serialization;
using MyPersonalShortner.Lib.Domain.Twitter;

namespace MyPersonalShortner.MvcApp.Areas.Api.DTO
{
    [DataContract(Name = "twitter")]
    public class ApiTwitterResult : ApiResult
    {
        [DataMember(Name = "access_token")]
        public AccessToken AccessToken { get; set; }
    }
}
