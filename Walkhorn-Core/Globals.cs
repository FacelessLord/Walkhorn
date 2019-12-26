using System;
using System.IO;

namespace Walkhorn_Core
{
    public static class Globals
    {
        public static char PathSeparator { get; private set; }

        public static string Path { get; private set; }
        public static string RelativeConfigurationPath { get; private set; }

        public static void Load()
        {
            PathSeparator = System.IO.Path.PathSeparator;
        }

        public static string GetConfigurationDestination()
        {
            return Path + PathSeparator + RelativeConfigurationPath;
        }
    }
}