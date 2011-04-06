using MyPersonalShortner.Lib.BaseConversion;

namespace MyPersonalShortner.Lib.Url
{
    public class UrlGenerator
    {
        private IBaseConversion baseConversion;
        private string chars;
        public UrlGenerator(IBaseConversion baseConversion, string chars)
        {
            this.baseConversion = baseConversion;
            this.chars = chars;
        }

        public string GeneratesFor(int value)
        {
            var values = this.baseConversion.Encode(value);
            var result = "";
            foreach (var index in values)
            {
                result += this.chars[index];
            }
            return result;
        }
    }
}