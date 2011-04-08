using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyPersonalShortner.MvcApp.Areas.Api.DTO
{
    [DataContract(Name = "apiErrorResult")]
    public class ApiErrorResult : ApiResult
    {
        [DataMember(Name="errors")]
        public List<string> Errors { get; set; }
    }
}