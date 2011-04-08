using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MyPersonalShortner.MvcApp.Areas.Api.DTO
{
    [DataContract(Name = "apiResult")]
    public class ApiResult
    {
        [DataMember(Name="success")]
        public bool Success { get; set; }
    }
}