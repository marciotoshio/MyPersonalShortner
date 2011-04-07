using System;
using System.Collections.Generic;

namespace MyPersonalShortner.Lib.Domain.UrlConversion
{
    public class Base10ToHash : IUrlConversion 
    {
        private string chars;
        private int theBase;

        public Base10ToHash(string chars)
        {
            this.chars = chars;
            this.theBase = chars.Length;
        }

        public string Encode(int value)
        {
            string hash = "";
            if (value >= this.theBase)
            {
                var remainder = value % this.theBase;
                hash += chars[remainder];
                value = value / this.theBase;
            }
            hash += chars[value];
            return hash;
        }

        public int Decode(string hash)
        {
            var result = 0;
            for (var i = hash.Length - 1; i >= 0; i--)
            {
                result += (chars.IndexOf(hash[i]) * (int)(Math.Pow(this.theBase, i)));
            }
            return result;
        }
    }
}
