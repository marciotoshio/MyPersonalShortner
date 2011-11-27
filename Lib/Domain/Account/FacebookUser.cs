using System.ComponentModel.DataAnnotations;
using MyPersonalShortner.Lib.Domain.Url;
using System.Collections.Generic;

namespace MyPersonalShortner.Lib.Domain.Account
{
    public class FacebookUser
    {
        public int Id { get; set; }
        [Required]
        public long FacebookId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<CustomUrl> CustomUrls { get; set; }

        public string ProfilePicture
        {
            get { return string.Format("https://graph.facebook.com/{0}/picture", FacebookId); }
        }
    }
}
