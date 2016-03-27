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
using Common.Logging;

namespace JoelRichPodcast
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            using (var container = GetContainer())
            {
                var mySettings = new SimpleConfigurationReader().GetSimple<ILocalMachineConfigSection>();
                var pg = container.GetInstance<PodcastGeneratorFactory>().GetPodcastGenerator();

                using (var xmlTextWriter = new XmlTextWriter(mySettings.OutputLocation, null) { Formatting = Formatting.Indented })
                {
                    pg.Generate(xmlTextWriter);
                }
            }
            Console.Write("Program Complete.");
            Console.ReadLine();
        }

        private static IContainer GetContainer()
        {
            return new Container(c =>
            {
                c.For<ILog>().Use(LogManager.GetLogger<Program>());

                c.For<IFeedGetter>().Use<JoelRichFeedGetter>();

                c.For<IFeedParser>().DecorateAllWith<LoggedFeedParser>();
                c.For<IFeedParser>().Use<JoelRichFeedParser>();


                c.For<ILinkAccessor>().Use<DefaultLinkAccessor>();
                c.For<ILinkParser>().DecorateAllWith<LoggedLinkedParser>();
                c.For<ILinkParser>().Add<YUTorahLinkParser>();
                c.For<ILinkParser>().Add<MP3LinkParser>();
                
                c.For<IFeedGenerator>().Use<JoelRichFeedGenerator>();
                
            });
        }
    }

    
}