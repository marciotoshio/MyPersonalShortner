using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPersonalShortner.Lib.Services
{
    public interface IShortnerService
    {
        string Shorten(string url);
        string Expand(string hash);
    }

    public class ShortnerService : IShortnerService
    {
        public string Shorten(string url)
        {
            throw new NotImplementedException();
        }

        public string Expand(string hash)
        {
            throw new NotImplementedException();
        }
    }
}
