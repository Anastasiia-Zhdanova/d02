using System.Collections;
using System.Collections.Generic;
using d02_ex01.Sources;

namespace d02_ex01
{
    public class Configuration
    {
        private List<IConfigurationSource> sources;

        public Configuration(List<IConfigurationSource> sources)
        {
            this.sources = sources;
        }

        public Hashtable parseSources()
        {
            sources.Sort((x, y) => x.Priority - y.Priority);
            Hashtable configurationResult = new();
            foreach (var source in sources)
            {
                Hashtable sourcesConfiguration = source.ReadHashtable();
                if (sourcesConfiguration == null)
                    return null;
                foreach (DictionaryEntry entry in sourcesConfiguration)
                {
                    configurationResult[entry.Key] = entry.Value;
                }
            }
            return configurationResult;
        }
    }
}