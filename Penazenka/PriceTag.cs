using System;
using System.Collections.Generic;
using System.Text;

namespace Penazenka
{
    public class PriceTag
    {
        public readonly long PerDay;
        public readonly long Price;

        public PriceTag(long price, long perDay)
        {
            PerDay = perDay;
            Price = price;
        }
    }
}
