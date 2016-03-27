using System;
using System.Xml.Linq;
using Common.Logging;
namespace PodcastGenerator
{

    public class LoggedFeedParser : IFeedParser
    {
        private readonly IFeedParser _feedParser;
        private ILog _log;

        public LoggedFeedParser(IFeedParser feedParser, ILog log)
        {
            _feedParser = feedParser;
            _log = log;
        }

        public ParsedRSSFeedItem Parse(XElement feed)
        {
            var item = _feedParser.Parse(feed);
            _log.Info($"Item parsed: {item.ItemLink} . {item.Links.Count} items");
            return item;
        }
    }
}