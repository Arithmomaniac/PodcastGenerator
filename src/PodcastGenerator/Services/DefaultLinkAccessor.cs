using CsQuery;
using System;

namespace PodcastGenerator
{
    public class DefaultLinkAccessor : ILinkAccessor
    {
        public bool TryGetLinkFile(string linkURL, out CQ doc)
        {
            try { 
                doc = CQ.CreateFromUrl(linkURL, null);
                return true;
            }
            catch
            {
                doc = null;
                return false;
            }
        }
    }
}