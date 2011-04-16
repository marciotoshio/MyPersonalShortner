using MyPersonalShortner.Lib.Domain.Twitter;
using TweetSharp;

namespace MyPersonalShortner.Lib.Infrastructure.TweetSharp
{
    public class TweetSharpImpl : ITwitter
    {
        private readonly TwitterService twitterService;

        public TweetSharpImpl(string consumerKey, string consumerSecret)
        {
            twitterService = new TwitterService(consumerKey, consumerSecret);
        }

        public string Authorize(string callbackUrl)
        {
            var requestToken = twitterService.GetRequestToken(callbackUrl); // <-- The registered callback URL
            var uri = twitterService.GetAuthorizationUri(requestToken);
            return uri.ToString();
        }

        public AccessToken Authenticate(string oauthToken, string oauthVerifier)
        {
            var requestToken = new OAuthRequestToken { Token = oauthToken };
            var accessToken = twitterService.GetAccessToken(requestToken, oauthVerifier);
            return new AccessToken {Token = accessToken.Token, TokenSecret = accessToken.TokenSecret};
        }

        public string GetScreenName(AccessToken accessToken)
        {
            twitterService.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
            return twitterService.VerifyCredentials().ScreenName;
        }

        public void UpdateStatus(AccessToken accessToken, string status)
        {
            twitterService.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
            twitterService.SendTweet(status);
        }
    }
}
