namespace MyPersonalShortner.Lib.Domain.Twitter
{
    public interface ITwitter
    {
        string Authorize(string callbackUrl);
        AccessToken Authenticate(string oauthToken, string oauthVerifier);
        string GetScreenName(AccessToken accessToken);
        void UpdateStatus(AccessToken accessToken, string status);
    }
}
