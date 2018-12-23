using ArbitrageCalculator.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArbitrageCalculator
{
    public partial class GameInfo : Form
    {
        Arbitrage arbitrage;
        public GameInfo(Arbitrage arbitrage)
        {
            InitializeComponent();
            this.arbitrage = arbitrage;

            label3.Text = arbitrage.firstTeam;
            label7.Text = arbitrage.firstTeamCoeff.ToString();
            label4.Text = arbitrage.secondTeam;
            label8.Text = arbitrage.secondTeamCoeff.ToString();
            label9.Text = arbitrage.firstTeamBookmaker;
            label10.Text = arbitrage.secondTeamBookmaker;
            label12.Text = arbitrage.getArbitrageValue().ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text != null)
            {
                float firstTeamMoney = (float)(Convert.ToDouble(richTextBox1.Text) / (arbitrage.firstTeamCoeff * arbitrage.getArbitrageValue()));
                float secondTeamMoney = (float)(Convert.ToDouble(richTextBox1.Text) / (arbitrage.secondTeamCoeff * arbitrage.getArbitrageValue()));
                MessageBox.Show(firstTeamMoney + " on " + arbitrage.firstTeam + " in " + arbitrage.firstTeamBookmaker + "\n" +
                    secondTeamMoney + " on " + arbitrage.secondTeam + " in " + arbitrage.secondTeamBookmaker + "\n", "Best bet", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Enter the sum first!");
            }
        }
    }
}
