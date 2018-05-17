using Penazenka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broker
{
    public partial class Broker : Form
    {
        public Broker()
        {
            InitializeComponent();
        }

        private long bestEarning;
        private int[] bestSchema;
        private int daysAmount;
        private int iterationCounter;
        private long startingMinerPerDay;

        private async void StartButton_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Reset();
            StatusLabel.Text = "Pracujem...";
            int miner2Day = int.MaxValue;
            int miner3Day = int.MaxValue;
            int miner4Day = int.MaxValue;

            await Task.Run(() =>
            {
                for (int i = daysAmount + 1; i > 0; i--)
                {
                    miner2Day = i;

                    for (int j = daysAmount + 1; j >= i; j--)
                    {
                        miner3Day = j;

                        for (int k = daysAmount + 1; k >= j; k--)
                        {
                            miner4Day = k;
                            iterationCounter++;

                            bool successfulStrategy = SimulateStrategy(miner2Day, miner3Day, miner4Day);
                            if (!successfulStrategy)
                            {
                                break;
                            }
                        }
                    }
                }
            });

            StatusLabel.Text = "Hotovo";
            ShowStats();

            watch.Stop();
            var elapsedMs = Math.Round(watch.ElapsedMilliseconds / 1000.0, 1);
            durationLabel.Text = elapsedMs.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="miner2Day">Day, when to start buying tier 2 miner</param>
        /// <param name="miner3Day">Day, when to start buying tier 3 miner</param>
        /// <param name="miner4Day">Day, when to start buying tier 4 miner</param>
        /// <returns>If this strategy is successful</returns>
        private bool SimulateStrategy(int miner2Day, int miner3Day, int miner4Day)
        {
            Wallet wallet = new Wallet();

            int highestMinerDay = 0;
            if (miner4Day < daysAmount + 1) highestMinerDay = miner4Day;
            else if (miner3Day < daysAmount + 1) highestMinerDay = miner3Day;
            else if (miner2Day < daysAmount + 1) highestMinerDay = miner2Day;

            //if the highest tier miner is never bought (strategy tries to buy it too early) it is not a successful strategy
            //starting with tier 0, default set to true
            bool wasHighestTierBought = false;

            if (wallet.Day == 0)
                wallet.BuyMiner(0, startingMinerPerDay);

            while (wallet.Day <= daysAmount + 30)
            {
                int minerTier = -1;
                if (wallet.Day > daysAmount)
                {
                    minerTier = -1;
                }
                else if (wallet.Day >= miner4Day)
                {
                    minerTier = 3;
                }
                else if (wallet.Day >= miner3Day)
                {
                    minerTier = 2;
                }
                else if (wallet.Day >= miner2Day)
                {
                    minerTier = 1;
                }
                else
                    minerTier = 0;

                try
                {
                    wallet.AdvanceOneDay(minerTier, 0);

                    if (!wasHighestTierBought)
                    {
                        int minersAmount = wallet.MinersAmount;

                        if (minersAmount > 0)
                        {
                            if (wallet.Day >= highestMinerDay &&
                                wallet.GetMiner(minersAmount - 1).ActivationDay >= highestMinerDay)
                            {
                                wasHighestTierBought = true;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    break;
                }
            }

            if (wallet.Balance > bestEarning)
            {
                bestEarning = wallet.Balance;
                bestSchema[0] = miner2Day;
                bestSchema[1] = miner3Day;
                bestSchema[2] = miner4Day;

                //ShowStats();
            }

            return wasHighestTierBought;
        }

        private void Reset()
        {
            daysAmount = int.Parse(daysCountBox.Text);
            startingMinerPerDay = long.Parse(startMinerBox.Text);
            bestSchema = new int[] { -1, -1, -1};
            bestEarning = 0;
            iterationCounter = 0;
            StatusLabel.Text = "Nečinný";

            ShowStats();
        }

        private void ShowStats()
        {
            SumLabel.Text = bestEarning.ToString();
            IterationLabel.Text = iterationCounter.ToString();

            string schema = $"v1.1 - deň {bestSchema[0]}, v1.2 - deň {(bestSchema[1] > daysAmount ? -1 : bestSchema[1])}, v2.0 - deň {(bestSchema[2] > daysAmount ? -1 : bestSchema[2])}";
            SchemaLabel.Text = schema;
        }
    }
}
