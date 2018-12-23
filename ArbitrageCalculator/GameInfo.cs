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
    }
}
