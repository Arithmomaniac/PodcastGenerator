using System;
using PodcastRssGenerator4DotNet;

namespace PodcastGenerator
{
    public interface IFeedGenerator
    {
        RssGenerator GetPodcastGenerator(PodcastGenerator.ParsedRSSFeedItem items);
    }
}
