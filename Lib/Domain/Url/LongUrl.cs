using System.ComponentModel.DataAnnotations;

namespace MyPersonalShortner.Lib.Domain.Url
{
    public class LongUrl
    {
        public int Id { get; set; }
        [Required]
        [UrlAttribute(ErrorMessage = "The url is invalid.")]
        public string Url { get; set; }
    }
}
