using System;
using System.Collections.Generic;

namespace MyPersonalShortner.Lib
{
    public class Base10ToN
    {
        private int theBase;

        public Base10ToN(int theBase)
        {
            this.theBase = theBase;
        }

        public IList<int> Encode(int value)
        {
            IList<int> encodedValues = new List<int>();
            if (value >= this.theBase)
            {
                var remainder = value % this.theBase;
                encodedValues.Add(remainder);
                value = value / this.theBase;
            }
            encodedValues.Add(value);
            return encodedValues;
        }

        public int Decode(int[] values)
        {
            var result = 0;
            for (var i = values.Length - 1; i >= 0; i--)
            {
                result += (values[i] * (int)(Math.Pow(this.theBase, i)));
            }
            return result;
        }
    }
}
