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

namespace WindowsFormsApp1
{
    public partial class Kalkulacka : Form
    {
        public Kalkulacka()
        {
            InitializeComponent();

            Reset();
        }

        private Wallet wallet;

        private void computeButton_Click(object sender, EventArgs e)
        {
            if (wallet.Day == 0)
                wallet.BuyMiner(0, long.Parse(startMinerBox.Text));

            for (int i = 0; i < int.Parse(leapBox.Text); i++)
            {
                int minerTier = -1;
                if (v10RadioButton.Checked)
                    minerTier = 0;
                else if (v11RadioButton.Checked)
                    minerTier = 1;
                else if (v12RadioButton.Checked)
                    minerTier = 2;
                else if (v20RadioButton.Checked)
                    minerTier = 3;

                try
                {
                    wallet.AdvanceOneDay(minerTier, long.Parse(checkOutDailyBox.Text));
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    break;
                }
            }

            ShowStats();
        }

        private void ShowStats()
        {
            dayLabel.Text = wallet.Day.ToString();
            balanceLabel.Text = wallet.Balance.ToString();
            perDayLabel.Text = wallet.PerDayTotal().ToString();
            minersListLabel.Text = wallet.MinersReport();
            voVreckuLabel.Text = $"{wallet.SavingsBalance.ToString()} ({ Math.Round(Convert.ToDecimal(wallet.SavingsBalance) * decimal.Parse(kurzBox.Text), 2)} €)";
            activeMinersLabel.Text = $"Aktívni mineri ({wallet.MinersAmount}):";
        }

        private void Reset()
        {
            wallet = new Wallet();

            voVreckuLabel.Text = wallet.SavingsBalance.ToString();
            minersListLabel.Text = "";

            ShowStats();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void cashoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                wallet.Withdraw(long.Parse(checkOutBox.Text));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            ShowStats();
        }
    }
}
