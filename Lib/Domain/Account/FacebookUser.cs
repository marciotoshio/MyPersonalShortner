using System.ComponentModel.DataAnnotations;
using MyPersonalShortner.Lib.Domain.Url;
using System.Collections.Generic;

namespace MyPersonalShortner.Lib.Domain.Account
{
    public class FacebookUser
    {
        public long FacebookId { get; set; }
        public string Name { get; set; }
        public string ProfilePicture
        {
            get { return string.Format("https://graph.facebook.com/{0}/picture", FacebookId); }
        }
    }
}
