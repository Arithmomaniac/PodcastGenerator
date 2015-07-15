using ConfigReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelRichPodcast
{
    public class SimpleConfigurationReader : ConfigurationReader
    {
        public T GetSimple<T>()
        {
            return base.SetupConfigOf<T>().ConfigBrowser.Get<T>();
        }
    }
}
