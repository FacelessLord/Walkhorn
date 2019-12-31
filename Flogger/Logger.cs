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

        private string _messageBase;
        private int _currentLevel = 30;
        private TextWriter _stdOut = Console.Out;

        public Func<(string level, string messageBase, DateTime time, string message), string> Format
            = tuple => $"{tuple.level}::{tuple.messageBase}::" +
                       $"{tuple.time.ToString(CultureInfo.InvariantCulture)}::{tuple.message}";

        public Logger(string messageBase)
        {
            _messageBase = messageBase;
        }

        public void SetLogLevel(string level)
        {
            if (levels.ContainsKey(level))
                _currentLevel = levels[level];
            else
                Error($"{level} is not allowed loglevel");
        }

        public void SetOutStream(TextWriter stream)
        {
            _stdOut = stream;
        } 
        public void SetFormat(Func<(string level, string messageBase, DateTime time, string message), string> format)
        {
            Format = format;
        }

        public void Log(string level, object message)
        {
            if (levels[level] <= _currentLevel) return;

            var time = DateTime.Now;
            var rawMessage = (level, MessageBase: _messageBase, time, $"{message}");
            _stdOut.WriteLine(Format(rawMessage));
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