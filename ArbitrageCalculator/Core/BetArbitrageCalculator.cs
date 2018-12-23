using System;
using System.Collections.Generic;
using System.Linq;

namespace ArbitrageCalculator.Core
{
    class BetArbitrageCalculator
    {
        List<Game> games = new List<Game>();

        List<Arbitrage> arbitrages = new List<Arbitrage>();

        public void addData(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                games.Add(new Game(data[i++], data[i++], Convert.ToDouble(data[i++].Replace('-', '0').Replace(',', '.')),
                    Convert.ToDouble(data[i++].Replace('-', '0').Replace(',', '.')), data[i]));
            }
            findArbitrages();
        }

        private void findArbitrages()
        {
            for (int i = 0; i < games.Count; i++)
            {
                for (int j = i + 1; j < games.Count; j++)
                {
                    Game fgame = games.ElementAt(i);
                    Game sgame = games.ElementAt(j);
                    if (fgame.firstTeam.Equals(sgame.firstTeam) && fgame.secondTeam.Equals(sgame.secondTeam))
                    {
                        if ((1 / fgame.firstTeamCoeff + 1 / sgame.secondTeamCoeff) < 1.5)
                        {
                            arbitrages.Add(new Arbitrage(fgame.firstTeam, sgame.secondTeam,
                                                    fgame.firstTeamCoeff, sgame.secondTeamCoeff,
                                                    fgame.bookmaker, sgame.bookmaker));
                        }
                        if ((1 / fgame.secondTeamCoeff + 1 / sgame.firstTeamCoeff) < 1.5)
                        {
                            arbitrages.Add(new Arbitrage(fgame.secondTeam, sgame.firstTeam,
                                                    fgame.secondTeamCoeff, sgame.firstTeamCoeff,
                                                    fgame.bookmaker, sgame.bookmaker));
                        }
                    }
                    else if (fgame.firstTeam.Equals(sgame.secondTeam) && fgame.secondTeam.Equals(sgame.firstTeam))
                    {
                        if ((1 / fgame.firstTeamCoeff + 1 / sgame.firstTeamCoeff) < 1.5)
                        {
                            arbitrages.Add(new Arbitrage(fgame.firstTeam, sgame.firstTeam,
                                                    fgame.firstTeamCoeff, sgame.firstTeamCoeff,
                                                    fgame.bookmaker, sgame.bookmaker));
                        }
                        if ((1 / fgame.secondTeamCoeff + 1 / sgame.secondTeamCoeff) < 1.5)
                        {
                            arbitrages.Add(new Arbitrage(fgame.secondTeam, sgame.secondTeam,
                                                    fgame.secondTeamCoeff, sgame.secondTeamCoeff,
                                                    fgame.bookmaker, sgame.bookmaker));
                        }
                    }
                }
            }
        }

        public Arbitrage getArbitrageById(int selectedIndex)
        {
            return arbitrages.ElementAt(selectedIndex);
        }

        public string[] ArrayOfGames()
        {
            return arbitrages.Select(arbitrage => arbitrage.ToString()).ToArray();
        }

        public Arbitrage BestArbitrage()
        {
            Arbitrage best = arbitrages.Aggregate((first, second) => first.getArbitrageValue() < second.getArbitrageValue() ? first : second);
            return best;
        }
    }
}
