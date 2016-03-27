using CsQuery;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using PodcastGenerator;

namespace JoelRichPodcast
{
	public class JoelRichFeedParser : IFeedParser
	{
		public JoelRichFeedParser()
		{
		}

		public ParsedRSSFeedItem Parse(XElement feed)
		{
			XElement item = feed.Descendants("item").First(x => !x.Element("title").Value.Contains("Special"));
			DateTime dateUpdated = DateTime.Parse(item.Element("pubDate").Value);
            string link = item.Element("link").Value;
            string content = item.Element(XName.Get("encoded", "http://purl.org/rss/1.0/modules/content/")).Value;
            ParsedRSSFeedItem parsedRSSFeedItem = new ParsedRSSFeedItem
            {
                ItemLink = link,
				DateUpdated = dateUpdated,
				Links = CQ.CreateFragment(content).Select("li").Has("a").Select(ParseLink).Where( x => x != null).ToList()
			};
			return parsedRSSFeedItem;
		}

		private static ParsedRSSFeedLink ParseLink(IDomObject linkNode)
		{
			ParsedRSSFeedLink parsedRSSFeedLink;
			CQ linkCq = new CQ(linkNode.Clone());
			CQ aCq = linkCq.Find("a");
			if (aCq.Any())
			{
				ParsedRSSFeedLink parsedRSSFeedLink1 = new ParsedRSSFeedLink
				{
					LinkURL = aCq.Attr<string>("href"),
					LinkTitle = aCq.First().Text()
				};
				ParsedRSSFeedLink link = parsedRSSFeedLink1;
				aCq.FirstElement().Remove();
				link.Description = linkCq.Text().Trim();
				parsedRSSFeedLink = link;
			}
			else
			{
				parsedRSSFeedLink = null;
			}
			return parsedRSSFeedLink;
		}
	}
}