using System.Xml.Linq;
namespace PodcastGenerator
{
	public interface IFeedParser
	{
        ParsedRSSFeedItem Parse(XElement feed);
	}
}