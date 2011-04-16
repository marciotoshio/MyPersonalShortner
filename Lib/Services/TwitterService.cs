using MyPersonalShortner.Lib.Domain.Twitter;

namespace MyPersonalShortner.Lib.Services
{
    public interface ITwitterService
    {
        string Authorize(string callbackUrl);
        AccessToken Authenticate(string oauthToken, string oauthVerifier);
        string GetScreenName(AccessToken accessToken);
        void UpdateStatus(AccessToken accessToken, string status);
    }

    public class TwitterService : ITwitterService
    {
        private readonly ITwitter twitter;
        public TwitterService(ITwitter twitter)
        {
            this.twitter = twitter;
        }

        public string Authorize(string callbackUrl)
        {
            return twitter.Authorize(callbackUrl);
        }

        public AccessToken Authenticate(string oauthToken, string oauthVerifier)
        {
            return twitter.Authenticate(oauthToken, oauthVerifier);
        }

        public  string GetScreenName(AccessToken accessToken)
        {
            return twitter.GetScreenName(accessToken);
        }

        public void UpdateStatus(AccessToken accessToken, string status)
        {
            twitter.UpdateStatus(accessToken, status);
        }
    }
}
