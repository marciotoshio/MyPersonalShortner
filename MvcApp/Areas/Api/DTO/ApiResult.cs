using System.Runtime.Serialization;

namespace MyPersonalShortner.MvcApp.Areas.Api.DTO
{
    [DataContract(Name = "apiResult")]
    public class ApiResult
    {
        [DataMember(Name="success")]
        public bool Success { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}