using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using FLogger;
using Newtonsoft.Json;

namespace Walkhorn_Core.Configurations
{
    public class Configuration
    {
        public bool DebugMode = true;
        public static Logger Logger = new Logger("Configuration");

        public Configuration()
        {
        }

        public static Configuration LoadFrom(IEnumerable<string> config)
        {
            return JsonConvert.DeserializeObject<Configuration>(config.Aggregate((a, b) => a + '\n' + b));
        }

        public static Configuration LoadFromFile(string file)
        {
            if (File.Exists(file)) return LoadFrom(File.ReadLines(file));

            Logger.Warning($"Configuration file {file} doesn't exist. Using default configuration.");
            return new Configuration();
        }

        public void SaveToFile(string file)
        {
            File.WriteAllText(file, JsonConvert.SerializeObject(this));
        }
    }
}