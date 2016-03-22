using ConfigReader;
using ConfigReader.Interfaces;
using PodcastRssGenerator4DotNet;
using System;
using System.Xml;
using System.Xml.Linq;
using PodcastGenerator;
using SimpleInjector;

namespace JoelRichPodcast
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var container = new Container()
)
            {
                var parsers = new ILinkParser[] { new MP3LinkParser(), new YUTorahLinkParser(new DefaultLinkAccessor()) };

                container.Register<IFeedParser, JoelRichFeedParser>();
                container.Register<IFeedGenerator>(() => new JoelRichFeedGenerator(parsers));
                container.Register<IFeedGetter>(() => new UrlFeedGetter($"http://www.torahmusings.com/category/audio/feed", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36"));

                
                var mySettings = new SimpleConfigurationReader().GetSimple<ILocalMachineConfigSection>();

                var pgg = new PodcastGeneratorGenerator();
                var pg = PodcastGeneratorGenerator.GetPodcastGenerator(
                            container.GetInstance<IFeedGetter>(),
                            container.GetInstance<IFeedParser>(),
                            container.GetInstance<IFeedGenerator>()
                        );

                using (var xmlTextWriter = new XmlTextWriter(mySettings.OutputLocation, null) { Formatting = Formatting.Indented })
                {
                    pg.Generate(xmlTextWriter);
                }
            }
        }        
    }
}