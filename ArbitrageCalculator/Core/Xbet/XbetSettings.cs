namespace Parser.Core.Xbet
{
    class XbetSettings : IParserSettings
    {
        public XbetSettings(string league)
        {
            if (league.Equals("National NFL League"))
            {
                BaseUrl = "https://1xbet.com/en/line/American-Football/68315-USA-NFL/";
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