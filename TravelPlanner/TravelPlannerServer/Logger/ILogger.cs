namespace TravelPlannerServer.Logger
{
    internal enum Level
        : byte
    {
        Info = 0,
        Warning,
        Error
    }

    internal interface ILogger
    {
        void Log(Level level, string message, string caller, string file, int line);
    }
}
