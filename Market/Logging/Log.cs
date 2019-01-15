using System;
using System.IO;

namespace Market.Logging
{
    public class Log
    {
        private const string LogPath = "log";

        public static void Write(string message)
        {
            Directory.CreateDirectory(LogPath);
            var fileName = $"{DateTime.Today.ToString("yyyy-MM-dd")}.txt";
            var file = Path.Combine(LogPath, fileName);
            var logLine = message + "\r\n";
            File.AppendAllText(file, logLine);
        }
    }
}
