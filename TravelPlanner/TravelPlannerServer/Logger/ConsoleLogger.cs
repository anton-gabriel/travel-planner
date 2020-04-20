using System;
using System.IO;

namespace TravelPlannerServer.Logger
{
    internal sealed class ConsoleLogger
        : ILogger
    {
        public void Log(Level level, string message, string caller, string file, int line)
        {
            Console.WriteLine($"[{level}] at [{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}]" +
                $" from [{Path.GetFileName(file)}][{caller}][line {line}]: {message}");
        }
    }
}
