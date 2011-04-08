namespace MyPersonalShortner.Lib.Domain.UrlConversion
{
    public interface IUrlConversion
    {
        string Encode(int value);
        int Decode(string hash);
    }
}
