using System;

namespace MyPersonalShortner.Lib.Domain.UrlConversion
{
    public class Base10ToHash : IUrlConversion 
    {
        private readonly string chars;
        private readonly int theBase;

        public Base10ToHash(string chars)
        {
            this.chars = chars;
            theBase = chars.Length;
        }

        public string Encode(int value)
        {
            var hash = "";
            if (value >= theBase)
            {
                var remainder = value % theBase;
                hash += chars[remainder];
                value = value / theBase;
            }
            hash += chars[value];
            return hash;
        }

        public int Decode(string hash)
        {
            var result = 0;
            for (var i = hash.Length - 1; i >= 0; i--)
            {
                result += (chars.IndexOf(hash[i]) * (int)(Math.Pow(theBase, i)));
            }
            return result;
        }
    }
}
