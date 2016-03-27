using PodcastRssGenerator4DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PodcastGenerator
{
    public class PodcastGeneratorFactory
    {
        IFeedGenerator _feedGenerator;
        IFeedGetter _feedGetter;
        IFeedParser _feedParser;
        public PodcastGeneratorFactory(IFeedGetter feedGetter, IFeedParser feedParser, IFeedGenerator feedGenerator)
        {
            _feedGetter = feedGetter;
            _feedGenerator = feedGenerator;
            _feedParser = feedParser;
        }

        public RssGenerator GetPodcastGenerator()
        {
            XElement feed = _feedGetter.GetFeed();
            ParsedRSSFeedItem feedInfo = _feedParser.Parse(feed);
            return _feedGenerator.GetPodcastGenerator(feedInfo);
        }
    }
}
