using System;
using System.IO;

namespace Walkhorn_Core
{
    public static class Globals
    {
        public static char PathSeparator { get; private set; }

        public static string PathBase { get; private set; } = "Walkhorn";
        public static string ConfigurationFolder { get; private set; } = "config";
        public static string ConfigurationFileName { get; private set; } = "config.cfg";

        public static void Load()
        {
            PathSeparator = '/';
        }

        public static string GetConfigurationDestination()
        {
            return ConfigurationFileName;//PathBase + PathSeparator + ConfigurationFolder + PathSeparator + ConfigurationFileName
        }
    }
}