using MyPersonalShortner.Lib.Domain.Twitter;

namespace MyPersonalShortner.ShortnerApp.Models
{
	public class ApiTwitterResult
	{
		public AccessToken AccessToken { get; set; }
		public string ScreenName { get; set; }
	}
}
