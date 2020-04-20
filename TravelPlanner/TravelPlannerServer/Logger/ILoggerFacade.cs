using System.Runtime.CompilerServices;

namespace TravelPlannerServer.Logger
{
    internal interface ILoggerFacade
    {
        void Info(string message, [CallerMemberName] string caller = "", [CallerFilePath] string file = "", [CallerLineNumber] int line = default);
        void Warn(string message, [CallerMemberName] string caller = "", [CallerFilePath] string file = "", [CallerLineNumber] int line = default);
        void Error(string message, [CallerMemberName] string caller = "", [CallerFilePath] string file = "", [CallerLineNumber] int line = default);
    }
}
