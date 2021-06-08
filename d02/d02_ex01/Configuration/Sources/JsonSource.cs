using System;
using System.Collections;
using System.IO;
using System.Text.Json;

namespace d02_ex01.Sources
{
    public class JsonSource : IConfigurationSource
    {
        private string fileName;
        private int _priority;

        public JsonSource(string fileName, int priority)
        {
            this.fileName = fileName;
            _priority = priority;
        }

        public Hashtable ReadHashtable()
        {
            try
            {
                string jsonString = File.ReadAllText(fileName);
                return (JsonSerializer.Deserialize<Hashtable>(jsonString));
            }
            catch (Exception)
            {
                return (null);
            }
        }

        public int Priority => _priority;
    }
}