using System;
using System.Collections.Generic;
using System.Text;

namespace Penazenka
{
    static class PriceList
    {
        private static PriceTag[] priceList = new PriceTag[]
            {
                new PriceTag(300, 14),
                //new PriceTag(3, 1),
                new PriceTag(1000, 51),
                new PriceTag(5000, 262),
                new PriceTag(50000, 2750)
            };

        public static PriceTag GetMiner(int tier)
        {
            if (tier >= 0 && tier < priceList.Length)
                return priceList[tier];
            else
                return null;
        }
    }
}
