using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPersonalShortner.Lib.Domain.UrlConversion
{
    public interface IUrlConversion
    {
        string Encode(int value);
        int Decode(string hash);
    }
}
