using CsQuery;
using PodcastRssGenerator4DotNet;
using System;
using PodcastGenerator;

namespace JoelRichPodcast
{
	internal class YUTorahLinkParser : ILinkParser
	{
        private readonly ILinkAccessor _accessor;

		public YUTorahLinkParser(ILinkAccessor accessor)
		{
			_accessor = accessor;
		}

		public YUTorahLinkParser() : this(new DefaultLinkAccessor())
		{
		}

		public Episode ParseLink(ParsedRSSFeedLink link)
		{
			if (!link.LinkURL.StartsWith("http://www.yutorah.org/lectures/lecture.cfm/"))
                return null;

            CQ doc;
			if (!_accessor.TryGetLinkFile(link.LinkURL, out doc))
                return null;

            doc = doc[".download a[title=\"Download this shiur\"]"];
		    string downloadurl = doc.Attr("href");
            if (downloadurl == null)
                return null;
		
            return new Episode
            {
                FileUrl = downloadurl,
                Permalink = link.LinkURL,
                Summary = link.Description,
                PublicationDate = DateTime.MinValue,
                Title = link.LinkTitle,
                FileType = "audio/mp3",
                Duration = "0:00"
            };
		}
	}
}