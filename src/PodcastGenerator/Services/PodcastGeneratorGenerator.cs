using PodcastRssGenerator4DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PodcastGenerator
{
    public class PodcastGeneratorGenerator
    {
        public static RssGenerator GetPodcastGenerator(IFeedGetter feedGetter, IFeedParser feedParser, IFeedGenerator feedGenerator)
        {
            XElement feed = feedGetter.GetFeed();
            ParsedRSSFeedItem feedInfo = feedParser.Parse(feed);
            return feedGenerator.GetPodcastGenerator(feedInfo);
        }
    }
}
