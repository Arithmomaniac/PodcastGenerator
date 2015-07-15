using PodcastRssGenerator4DotNet;

namespace PodcastGenerator
{
	public interface ILinkParser
	{
		Episode ParseLink(ParsedRSSFeedLink link);
	}
}