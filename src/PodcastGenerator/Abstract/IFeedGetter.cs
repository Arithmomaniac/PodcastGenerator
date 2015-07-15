using System.Xml.Linq;

namespace PodcastGenerator
{
	public interface IFeedGetter
	{
		XElement GetFeed();
	}
}