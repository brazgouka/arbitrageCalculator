using AngleSharp.Parser.Html;
using System;

namespace Parser.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;

        HtmlLoader loader;

        public event Action<T> OnNewData;
        public event Action<string> OnCompleted;
        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }
        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
            loader = new HtmlLoader(parserSettings);
        }

        private async void Worker()
        {
            if (loader != null)
            {
                var source = await loader.GetSource();
                var domParser = new HtmlParser();

                var document = await domParser.ParseAsync(source);

                var result = parser.Parse(document);

                OnNewData?.Invoke(result);

                OnCompleted?.Invoke(loader.url);
            }
        }


    }
}
