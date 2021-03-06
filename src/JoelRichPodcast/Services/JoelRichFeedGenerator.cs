using PodcastRssGenerator4DotNet;
using System;
using System.Collections.Generic;
using PodcastGenerator;
using System.Linq;

namespace JoelRichPodcast
{
    internal class JoelRichFeedGenerator : IFeedGenerator
    {
        private readonly ICollection<ILinkParser> _parsers;

        public JoelRichFeedGenerator(params ILinkParser[] parsers) : this((ICollection<ILinkParser>)parsers)
        {
        }

        public JoelRichFeedGenerator(ICollection<ILinkParser> parsers)
        {
            if (parsers?.Any() != true)
                throw new ArgumentException("parsers are required", nameof(parsers));
            this._parsers = parsers;
        }

        public RssGenerator GetPodcastGenerator(ParsedRSSFeedItem items)
        {
            RssGenerator rssGenerator = new RssGenerator
            {

                Title = "Joel Rich Audio Roundup Podcast",
                Description = "Joel Rich's famous Audio Roundup picks as a podcast.  = Beta)",
                HomepageUrl = "http://www.torahmusings.com/category/audio/",
                AuthorName = "Joel Rich / Avi Levin",
                AuthorEmail = "email@avilevin.net",
                Episodes = new List<Episode>(),
                ImageUrl = "http://i0.wp.com/torahmusings.com/wp-content/uploads/2013/08/microphone.jpg",
                iTunesCategory = "Temp",
                iTunesSubCategory = "Temp",
            };

            foreach (ParsedRSSFeedLink item in items.Links)
            {
                foreach (ILinkParser parser in _parsers)
                {
                    Episode episode = parser.ParseLink(item);
                    if (episode != null)
                    {
                        rssGenerator.Episodes.Add(episode);
                        break;
                    }
                }
            }
            return rssGenerator;
        }
    }
}