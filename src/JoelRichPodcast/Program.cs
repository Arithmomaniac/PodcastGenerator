using ConfigReader;
using ConfigReader.Interfaces;
using PodcastRssGenerator4DotNet;
using System;
using System.Xml;
using System.Xml.Linq;
using PodcastGenerator;

namespace JoelRichPodcast
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var parsers = new ILinkParser[] { new MP3LinkParser(), new YUTorahLinkParser(new DefaultLinkAccessor()) };
            var mySettings = new SimpleConfigurationReader().GetSimple<ILocalMachineConfigSection>();

            var pgg = new PodcastGeneratorGenerator();
            var pg = pgg.GetPodcastGenerator(
                        new UrlFeedGetter($"http://www.torahmusings.com/category/audio/feed", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36"),
                        new JoelRichFeedParser(),
                        new JoelRichFeedGenerator(parsers)
                    );
            pg.Generate(
                        new XmlTextWriter(mySettings.OutputLocation, null) {Formatting = Formatting.Indented}
                    );
        }        
    }
}