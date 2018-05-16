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
        private int startingMinerPerDay;

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

                            SimulateStrategy(miner2Day, miner3Day, miner4Day);
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

        private void SimulateStrategy(int miner2Day, int miner3Day, int miner4Day)
        {
            Wallet wallet = new Wallet();
            if (wallet.Day == 0)
                wallet.BuyMiner(0, startingMinerPerDay);

            for (int i = 0; i <= daysAmount + 30; i++)
            {
                int minerTier = -1;
                if (wallet.Day > daysAmount)
                    minerTier = -1;
                else if (wallet.Day >= miner4Day)
                    minerTier = 3;
                else if (wallet.Day >= miner3Day)
                    minerTier = 2;
                else if (wallet.Day >= miner2Day)
                    minerTier = 1;
                else
                    minerTier = 0;

                try
                {
                    wallet.AdvanceOneDay(minerTier, 0);
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
        }

        private void Reset()
        {
            daysAmount = int.Parse(daysCountBox.Text);
            startingMinerPerDay = int.Parse(startMinerBox.Text);
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
