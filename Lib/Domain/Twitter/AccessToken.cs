namespace MyPersonalShortner.Lib.Domain.Twitter
{
    public struct AccessToken
    {
        public string Token { get; set; }
        public string TokenSecret { get; set; }

        public override string ToString()
        {
            return string.Format("{{\"Token\": {0}, \"TokenSecret\": {1}}}", Token, TokenSecret);
        }
    }
}
