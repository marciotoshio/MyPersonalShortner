using MyPersonalShortner.Lib.Domain.Twitter;
using TweetSharp;

namespace MyPersonalShortner.Lib.Infrastructure.TweetSharp
{
    public class TweetSharpImpl : ITwitter
    {
        private readonly string consumerKey;
        private readonly string consumerSecret;

        public TweetSharpImpl(string consumerKey, string consumerSecret)
        {
            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;
        }

        public string Authorize(string callbackUrl)
        {
            // Step 1 - Retrieve an OAuth Request Token
            var service = new TwitterService(consumerKey, consumerSecret);
            var requestToken = service.GetRequestToken(callbackUrl); // <-- The registered callback URL

            // Step 2 - Redirect to the OAuth Authorization URL
            var uri = service.GetAuthorizationUri(requestToken);
            return uri.ToString();
        }

        public AccessToken Authenticate(string oauthToken, string oauthVerifier)
        {
            var requestToken = new OAuthRequestToken { Token = oauthToken };

            // Step 3 - Exchange the Request Token for an Access Token
            var service = new TwitterService(consumerKey, consumerSecret);
            var accessToken = service.GetAccessToken(requestToken, oauthVerifier);

            // Step 4 - User authenticates using the Access Token
            service.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
            return new AccessToken {Token = accessToken.Token, TokenSecret = accessToken.TokenSecret};
        }

        public void UpdateStatus(AccessToken accessToken, string status)
        {
            var service = new TwitterService();
            service.AuthenticateWith(consumerKey, consumerSecret, accessToken.Token, accessToken.TokenSecret);
            service.SendTweet(status);
        }
    }
}
