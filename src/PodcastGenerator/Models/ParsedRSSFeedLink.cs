using System;
using System.Runtime.CompilerServices;

namespace PodcastGenerator
{
	public class ParsedRSSFeedLink
	{
		public string Description
		{
			get;
			set;
		}

		public string LinkTitle
		{
			get;
			set;
		}

		public string LinkURL
		{
			get;
			set;
		}

		public ParsedRSSFeedLink()
		{
		}
	}
}