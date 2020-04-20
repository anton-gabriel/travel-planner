using System;
using System.IO;
using TravelPlannerServer.Utils.Constants;

namespace TravelPlannerServer.Logger
{
    internal sealed class FileLogger
        : ILogger
    {
        public void Log(Level level, string message, string caller, string file, int line)
        {
            using StreamWriter stream = File.AppendText(Paths.LogFile);
            stream.WriteLine($"[{level}] at [{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}] " +
                $"from [{Path.GetFileName(file)}][{caller}][line {line}]: {message}");
        }
    }
}
