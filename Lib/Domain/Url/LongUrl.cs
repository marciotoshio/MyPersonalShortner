using System.ComponentModel.DataAnnotations;
using MyPersonalShortner.Lib.Domain.CustomValidators;

namespace MyPersonalShortner.Lib.Domain.Url
{
    public class LongUrl
    {
        public int Id { get; set; }
        [Required]
        [Url]
        public string Url { get; set; }
    }
}
