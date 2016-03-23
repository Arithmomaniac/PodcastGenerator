using ConfigReader;
using ConfigReader.Interfaces;
using PodcastRssGenerator4DotNet;
using System;
using System.Xml;
using System.Xml.Linq;
using PodcastGenerator;
using StructureMap;
using JoelRichPodcast.Services;
using System.Collections.Generic;

namespace JoelRichPodcast
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            using (var container = new Container())
            {
                var parsers = new ILinkParser[] { new MP3LinkParser(), new YUTorahLinkParser(new DefaultLinkAccessor()) };
                container.Configure( c =>
                {
                    c.For<IFeedParser>().Use<JoelRichFeedParser>();
                    c.For<IFeedGenerator>().Use<JoelRichFeedGenerator>()
                        .Ctor<ILinkParser[]>().Is(parsers);
                    c.For<IFeedGetter>().Use<JoelRichFeedGetter>();
                });

                var mySettings = new SimpleConfigurationReader().GetSimple<ILocalMachineConfigSection>();
                var pg = container.GetInstance<PodcastGeneratorGenerator>().GetPodcastGenerator();

                using (var xmlTextWriter = new XmlTextWriter(mySettings.OutputLocation, null) { Formatting = Formatting.Indented })
                {
                    pg.Generate(xmlTextWriter);
                }
            }
        }        
    }
}