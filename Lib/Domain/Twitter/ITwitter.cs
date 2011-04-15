namespace MyPersonalShortner.Lib.Domain.Twitter
{
    public interface ITwitter
    {
        string Authorize(string callbackUrl);
        AccessToken Authenticate(string oauthToken, string oauthVerifier);
        void UpdateStatus(AccessToken accessToken, string status);
    }
}
