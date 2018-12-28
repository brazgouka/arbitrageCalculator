using AngleSharp.Parser.Html;
using System;

namespace ArbitrageCalculator.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;

        HtmlLoader loader;

        public event Action<T> NewData;
        public event Action<object> Completed;

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
            loader = new HtmlLoader(parserSettings);
        }

        public async void Start() 
        {
                if (loader != null)
                {
                    var source = await loader.GetSource();
                    var domParser = new HtmlParser();

                    var document = await domParser.ParseAsync(source);

                    var result = parser.Parse(document);

                    NewData?.Invoke(result);

                    Completed?.Invoke(this);
                }
        }


    }
}
