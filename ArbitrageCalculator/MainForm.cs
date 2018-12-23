using ArbitrageCalculator.Core;
using ArbitrageCalculator.Core.Marathon;
using ArbitrageCalculator.Core.Xbet;
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
    public partial class MainForm : Form
    {

        List<ParserWorker<string[]>> parsers = new List<ParserWorker<string[]>>();

        BetArbitrageCalculator arbitrageCalculator;

        public MainForm()
        {
            InitializeComponent();

            arbitrageCalculator = new BetArbitrageCalculator();
            listBox1.SelectedIndex = 0;
            progressBar1.Step = 50;
        }

        private void timer1_Tick(object obj)
        {
            progressBar1.PerformStep();
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void Parser_NewData(string[] arg2)
        {
            ListTitles.Items.AddRange(arg2);
        }
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            parsers.Add(new ParserWorker<string[]>(new XbetParser(), new XbetSettings(listBox1.Text)));
            parsers.Add(new ParserWorker<string[]>(new MarathonParser(), new MarathonSettings(listBox1.Text)));
            foreach (var parser in parsers)
            {
                parser.NewData += arbitrageCalculator.addData;
                parser.Completed += timer1_Tick;
                parser.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parser_NewData(arbitrageCalculator.ArrayOfGames());
            ListTitles.SelectedIndex = 0;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GameInfo gameInfo = new GameInfo(arbitrageCalculator.BestArbitrage());
            gameInfo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GameInfo gameInfo = new GameInfo(arbitrageCalculator.getArbitrageById(ListTitles.SelectedIndex));
            gameInfo.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
