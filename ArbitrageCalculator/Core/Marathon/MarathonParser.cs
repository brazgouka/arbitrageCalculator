using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom.Html;

namespace ArbitrageCalculator.Core.Marathon
{
    class MarathonParser : IParser<string[]>
    {
        public string bookmakerName = "Marathon";

        public string[] Parse(IHtmlDocument document)
        {
            var games = new List<string>();

            var teamNames = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("member-name"));

            var coeffs = document.QuerySelectorAll("span").Where(item => item.ClassName != null && item.ClassName.Contains("selection-link"));
            
            for (int j = 0, i = 0; j < teamNames.Count(); j++, i++)
            {
                games.Add(teamNames.ElementAt(j++).TextContent.Trim());
                games.Add(teamNames.ElementAt(j).TextContent.Trim());
                games.Add(coeffs.ElementAt(i++).TextContent.Trim());
                games.Add(coeffs.ElementAt(i).TextContent.Trim());
                games.Add(bookmakerName);
            }
            return games.ToArray();
        }
    }
}
