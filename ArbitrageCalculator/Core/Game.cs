using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbitrageCalculator.Core
{
    class Game
    {
        public string firstTeam { get; }

        public string secondTeam { get; }

        public double firstTeamCoeff { get; }

        public double secondTeamCoeff { get; }

        public string bookmaker { get; }
        public Game(string firstTeam, string secondTeam, double firstTeamCoeff, double secondTeamCoeff, string bookmaker)
        {
            this.firstTeam = firstTeam;
            this.secondTeam = secondTeam;
            this.firstTeamCoeff = firstTeamCoeff;
            this.secondTeamCoeff = secondTeamCoeff;
            this.bookmaker = bookmaker;
        }
        
    }
}
