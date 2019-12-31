using System.Collections.Generic;
using System.IO;
using System.Linq;
using FLogger;
using Newtonsoft.Json;

namespace Walkhorn_Core.Configurations
{
    public class Configuration
    {
        public bool DebugMode = true;
        private static Logger Logger = new Logger("Configuration");

        public static Configuration LoadFrom(IEnumerable<string> config)
        {
            return JsonConvert.DeserializeObject<Configuration>(config.Aggregate((a, b) => a + '\n' + b));
        }

        public static Configuration LoadFromFile(string file)
        {
            if (File.Exists(file)) return LoadFrom(File.ReadLines(file));

            Logger.Warning($"Configuration file {file} doesn't exist. Using default configuration.");
            var config = new Configuration();
            config.SaveToFile(file);
            return config;
        }

        public void SaveToFile(string file)
        {
            File.WriteAllText(file, JsonConvert.SerializeObject(this));
        }
    }
}