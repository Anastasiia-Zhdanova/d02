using System;
using System.Collections;
using System.IO;
using System.Text.Json;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace d02_ex01.Sources
{
    public class YamlSource : IConfigurationSource
    {
        private string fileName;
        private int _priority;

        public YamlSource(string fileName, int priority)
        {
            this.fileName = fileName;
            _priority = priority;
        }

        public Hashtable ReadHashtable()
        {
            try
            {
                string yamlString = File.ReadAllText(fileName);
                var deserializer = new DeserializerBuilder().Build();
                return (deserializer.Deserialize<Hashtable>(yamlString));;
            }
            catch (Exception)
            {
                return (null);
            }
        }

        public int Priority => _priority;
    }
}