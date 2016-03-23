using PodcastGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelRichPodcast.Services
{
    class JoelRichFeedGetter : UrlFeedGetter
    {
        private const string useragent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36";
        private const string torahMusingsUrl = "http://www.torahmusings.com/category/audio/feed";

        public JoelRichFeedGetter():base(torahMusingsUrl, useragent){ }
    }
}
