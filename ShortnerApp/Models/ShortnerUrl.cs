using System.ComponentModel.DataAnnotations;

namespace MyPersonalShortner.ShortnerApp.Models
{
	public class ShortnerUrl
	{
		[Required]
		public string Url { get; set; }
	}
}