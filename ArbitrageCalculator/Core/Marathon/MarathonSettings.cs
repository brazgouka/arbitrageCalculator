namespace Parser.Core.Habra
{
    class HabraSettings : IParserSettings
    {
        public HabraSettings(string league)
        {
            if (league.Equals("National NFL League"))
            {
                BaseUrl = "https://www.marathonbet.com/en/betting/American+Football/NFL/";
            }
            else if (league.Equals("Mexico LFA League"))
            {

            }
            else if (league.Equals("USA AFL League"))
            {

            }
        }
        public string BaseUrl { get; set; }
    }
}