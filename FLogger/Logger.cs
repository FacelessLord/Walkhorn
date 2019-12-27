using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace FLogger
{
    public class Logger
    {
        public static Dictionary<string, int> levels = new Dictionary<string, int>()
        {
            {"Undefined", 0},
            {"Debug", 10},
            {"Info", 20},
            {"Warning", 30},
            {"Error", 40},
            {"Critical", 50},
            {"Fatal", 100}
        };

        public string MessageBase;
        public int CurrentLevel = 30;
        public TextWriter StdOut = Console.Out;

        public Func<(string level, string messageBase, DateTime time, string message), string> Format
            = tuple => $"{tuple.level}::{tuple.messageBase}::" +
                       $"{tuple.time.ToString(CultureInfo.InvariantCulture)}::{tuple.message}";

        public Logger(string messageBase)
        {
            MessageBase = messageBase;
        }

        public void SetLogLevel(string level)
        {
            if (levels.ContainsKey(level))
                CurrentLevel = levels[level];
            else
                Error($"{level} is not allowed loglevel");
        }

        public void SetOutStream(TextWriter stream)
        {
            StdOut = stream;
        }

        public void Log(string level, object message)
        {
            if (levels[level] <= CurrentLevel) return;

            var time = DateTime.Now;
            var rawMessage = (level, MessageBase, time, $"{message}");
            StdOut.WriteLine(Format(rawMessage));
        }

        public void Debug(object message)
        {
            Log("Debug", message);
        }

        public void Info(object message)
        {
            Log("Info", message);
        }

        public void Warning(object message)
        {
            Log("Warning", message);
        }

        public void Error(object message)
        {
            Log("Error", message);
        }

        public void Critical(object message)
        {
            Log("Critical", message);
        }

        public void Fatal(object message)
        {
            Log("Fatal", message);
        }
    }
}