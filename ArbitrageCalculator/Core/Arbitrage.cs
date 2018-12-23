using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbitrageCalculator.Core
{
    public class Arbitrage
    {
        public string firstTeam { get; }

        public string secondTeam { get; }

        public double firstTeamCoeff { get; }

        public double secondTeamCoeff { get; }

        public string firstTeamBookmaker { get; }

        public string secondTeamBookmaker { get; }

        public Arbitrage(string firstTeam, string secondTeam, double firstTeamCoeff, double secondTeamCoeff, string firstTeamBookmaker, string secondTeamBookmaker)
        {
            this.firstTeam = firstTeam;

            this.secondTeam = secondTeam;

            this.firstTeamCoeff = firstTeamCoeff;

            this.secondTeamCoeff = secondTeamCoeff;

            this.firstTeamBookmaker = firstTeamBookmaker;

            this.secondTeamBookmaker = secondTeamBookmaker;
        }

        public double getArbitrageValue()
        {

            return (1 / firstTeamCoeff + 1 / secondTeamCoeff);
        }
        public override string ToString()
        {
            return $"{firstTeam} ({firstTeamBookmaker})   <--->   {secondTeam} ({secondTeamBookmaker})";
        }
    }
}
