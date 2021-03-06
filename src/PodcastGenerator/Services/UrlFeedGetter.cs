using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PodcastGenerator
{
    public class UrlFeedGetter : IFeedGetter
    {
        private readonly string _url;

        private readonly string _useragent;

        public UrlFeedGetter(string url, string useragent)
        {
            this._url = url;
            this._useragent = useragent;
        }

        public XElement GetFeed()
        {
            XElement xElement;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", this._useragent);
                using (HttpResponseMessage response = client.GetAsync(this._url+"?"+Guid.NewGuid()).Result)
                using (var responseContent = response.Content)
                {
                    var stream = responseContent.ReadAsStringAsync().Result;
                    xElement = XElement.Parse(stream);
                }
            }
            return xElement;
        }
    }
}