using MyPersonalShortner.Lib.BaseConversion;
using System.Collections.Generic;

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

        public int IdFor(string shortUrl)
        {
            var values = new int[shortUrl.Length];
            int i = 0;
            foreach (var c in shortUrl)
            {
                values.SetValue(chars.IndexOf(c), i++);
            }
            var result = this.baseConversion.Decode(values);
            return result;
        }
    }
}