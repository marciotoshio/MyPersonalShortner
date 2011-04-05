using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPersonalShortner.Lib.BaseConversion
{
    public interface IBaseConversion
    {
        IList<int> Encode(int value);
        int Decode(int[] values);
    }
}
