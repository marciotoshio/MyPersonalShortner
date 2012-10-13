using MyPersonalShortner.ShortnerApp.Helpers;

namespace MyPersonalShortner.ShortnerApp.Models
{
	public class ApiShortenResult
	{
		public string Url { get { return string.Format("{0}/{1}", AppHelper.GetFullHostAddress(), Hash); } }
		public string Hash { get; set; }
		public string LongUrl { get; set; }
	}
}
