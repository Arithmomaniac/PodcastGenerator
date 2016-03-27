using System;
using Common.Logging;
using PodcastRssGenerator4DotNet;

namespace PodcastGenerator
{

    public class LoggedLinkedParser : ILinkParser
    {
        private readonly ILog _log;
        private readonly ILinkParser _parser;
        private readonly string _parserClass;

        public LoggedLinkedParser(ILinkParser parser, ILog log)
        {
            _parser = parser;
            _parserClass = parser.GetType().Name;
            _log = log;
        }
        public Episode ParseLink(ParsedRSSFeedLink link)
        {
            var episode = _parser.ParseLink(link);
            var parsedVerbiage = (episode == null ? "could NOT parse" : "PARSED");
            _log.Debug($"{_parserClass} {parsedVerbiage} {link.LinkURL}");
            return episode;
        }
    }
}