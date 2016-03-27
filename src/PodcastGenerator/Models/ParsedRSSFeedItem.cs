using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PodcastGenerator
{
	public class ParsedRSSFeedItem
	{
        public string ItemLink { get; set; }
		public DateTime DateUpdated { get; set; }
		public List<ParsedRSSFeedLink> Links { get; set; }
	}
}