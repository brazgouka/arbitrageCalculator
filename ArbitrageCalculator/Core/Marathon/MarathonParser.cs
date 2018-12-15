using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom.Html;

namespace Parser.Core.Habra
{
    class HabraParser : IParser<string[]>
    {
        public string bookmakerName = "Marathon";

        public string[] Parse(IHtmlDocument document)
        {
            var games = new List<string>();

            var countryNames = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("member-name"));

            var coeffs = document.QuerySelectorAll("span").Where(item => item.ClassName != null && item.ClassName.Contains("selection-link"));
            
            for (int j = 0, i = 0; j < countryNames.Count(); j++, i++)
            {
                games.Add(countryNames.ElementAt(j++).TextContent.Trim());
                games.Add(countryNames.ElementAt(j).TextContent.Trim());
                games.Add(coeffs.ElementAt(i++).TextContent.Trim());
                games.Add(coeffs.ElementAt(i).TextContent.Trim());
                games.Add(bookmakerName);
            }
            return games.ToArray();
        }
    }
}
