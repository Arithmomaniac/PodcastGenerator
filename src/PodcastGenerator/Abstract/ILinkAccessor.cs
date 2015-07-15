using CsQuery;
using System;

namespace PodcastGenerator
{
	public interface ILinkAccessor
	{
		bool TryGetLinkFile(string linkURL, out CQ doc);
	}
}