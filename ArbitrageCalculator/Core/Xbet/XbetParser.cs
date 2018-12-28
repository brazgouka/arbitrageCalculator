using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace ArbitrageCalculator.Core.Xbet
{
    class XbetParser : IParser<string[]>
    {
        public string bookmakerName = "1XBet";
        public string[] Parse(IHtmlDocument document)
        {
            var games = new List<string>();

            var teamNames = document.QuerySelectorAll("span").Where(item => item.ClassName != null && item.ClassName.Equals("c-events__team"));
            var coeffs = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("c-bets__bet c-bets__bet_coef c-bets__bet_sm"));
            
            for (int j = 0, i = 0; j < teamNames.Count(); j++)
            {
                games.Add(teamNames.ElementAt(j++).TextContent.Trim());
                games.Add(teamNames.ElementAt(j).TextContent.Trim());
                games.Add(coeffs.ElementAt(i++).TextContent.Trim());
                i++;
                games.Add(coeffs.ElementAt(i++).TextContent.Trim());
                i += 15;
                games.Add(bookmakerName);
            }
            return games.ToArray();
        }
    }
}
