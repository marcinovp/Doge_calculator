using System;
using System.Collections.Generic;
using System.Text;

namespace Penazenka
{
    public class Miner
    {
        private const int LIFETIME = 30;

        private int endingDay;
        private int activationDay;
        private long perDay;

        public int EndingDay { get => endingDay; }
        public int ActivationDay { get => activationDay; }
        public long PerDay { get => perDay; }

        public Miner(int currentDay, long perDay)
        {
            this.activationDay = currentDay;
            this.endingDay = activationDay + LIFETIME;
            this.perDay = perDay;
        }

        public string ToString(int currentDay)
        {
            return perDay.ToString() + " DOGE/deň   " + (endingDay - currentDay).ToString() + " dní zostáva";
        }
    }
}
