using System;
using System.Collections.Generic;

namespace Penazenka
{
    public class Wallet
    {
        public int Day { get; private set; }
        public long Balance { get; private set; }
        public long SavingsBalance { get; private set; }

        private List<Miner> miners;

        public Wallet()
        {
            Day = 0;
            Balance = 0;
            SavingsBalance = 0;
            miners = new List<Miner>();
        }

        public void AdvanceOneDay(int minerTierToBuy = -1, long cashOutAmount = 0)
        {
            Withdraw(cashOutAmount);

            BuyMiners(minerTierToBuy);

            int minersCount = miners.Count;
            for (int i = 0; i < minersCount; i++)
            {
                Balance += miners[i].PerDay;
            }

            Day++;

            RemoveOverdueMiners();
        }

        public void Withdraw(long amount)
        {
            if (Balance < amount)
                throw new Exception($"Balance is lower than amount to withdraw. Withdraw amount: {amount}, balance: {Balance}");
            Balance -= amount;
            SavingsBalance += amount;
        }

        private void BuyMiners(int tier)
        {
            PriceTag minerToBuy = PriceList.GetMiner(tier);

            if (minerToBuy == null)
                return;

            while (Balance >= minerToBuy.Price)
            {
                BuyMiner(minerToBuy);
            }
        }

        public void BuyMiner(PriceTag minerItem)
        {
            BuyMiner(minerItem.Price, minerItem.PerDay);
        }

        public void BuyMiner(long price, long perDay)
        {
            if (Balance < price)
                throw new Exception($"Balance is lower than miner price. Price: {price}, balance: {Balance}");

            miners.Add(new Miner(Day, perDay));
            Balance -= price;
        }

        private void RemoveOverdueMiners()
        {
            //miners.RemoveAll((x) => Day >= x.EndingDay);
            for (int i = miners.Count - 1; i >= 0; i--)
            {
                if (Day >= miners[i].EndingDay)
                    miners.RemoveAt(i);
            }
        }

        public string MinersReport()
        {
            string minersListText = "";
            foreach (var miner in miners)
            {
                minersListText += miner.ToString(Day) + "\n";
            }

            return minersListText;
        }

        public int MinersAmount { get { return miners.Count; } }

        public long PerDayTotal()
        {
            long perDayTotal = 0;
            foreach (var miner in miners)
            {
                perDayTotal += miner.PerDay;
            }
            return perDayTotal;
        }
    }
}
