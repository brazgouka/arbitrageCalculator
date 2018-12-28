namespace ArbitrageCalculator.Core.Marathon
{
    class MarathonSettings : IParserSettings
    {
        public MarathonSettings(string league)
        {
            if (league.Equals("National NFL League"))
            {
                BaseUrl = "https://www.marathonbet.com/en/betting/American+Football/NFL/";
            }
            else if (league.Equals("Mexico LFA League"))
            {
                BaseUrl = "https://www.marathonbet.com/en/betting/American+Football/NFL/";
            }
            else if (league.Equals("USA AFL League"))
            {
                BaseUrl = "https://www.marathonbet.com/en/betting/American+Football/NFL/";
            }
        }
        public string BaseUrl { get; set; }
    }
}