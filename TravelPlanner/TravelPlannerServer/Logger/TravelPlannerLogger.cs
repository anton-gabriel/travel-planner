using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TravelPlannerServer.Logger
{
    internal class TravelPlannerLogger
        : ILoggerFacade
    {
        #region Constructors
        private TravelPlannerLogger()
        {
            Loggers = new HashSet<ILogger>();
        }
        #endregion

        #region Singleton
        private static readonly Lazy<TravelPlannerLogger> lazy = new Lazy<TravelPlannerLogger>(() => new TravelPlannerLogger());
        public static TravelPlannerLogger Instance => lazy.Value;
        #endregion

        #region Properties
        private HashSet<ILogger> Loggers { get; set; }
        #endregion

        #region Public methods
        public bool AddLogger(ILogger logger)
        {
            return lazy.IsValueCreated ?
                !Loggers.Contains(logger) ? Loggers.Add(logger) : false :
                false;
        }
        public bool RemoveLogger(ILogger logger)
        {
            return lazy.IsValueCreated ? Loggers.Remove(logger) : false;
        }
        #endregion


        #region ILoggerFacade
        public void Error(string message, [CallerMemberName] string caller = "", [CallerFilePath] string file = "", [CallerLineNumber] int line = default)
        {
            if (lazy.IsValueCreated)
            {
                foreach (var logger in Loggers)
                {
                    logger.Log(Level.Error, message, caller, file, line);
                }
            }
        }

        public void Info(string message, [CallerMemberName] string caller = "", [CallerFilePath] string file = "", [CallerLineNumber] int line = default)
        {
            if (lazy.IsValueCreated)
            {
                foreach (var logger in Loggers)
                {
                    logger.Log(Level.Info, message, caller, file, line);
                }
            }
        }

        public void Warn(string message, [CallerMemberName] string caller = "", [CallerFilePath] string file = "", [CallerLineNumber] int line = default)
        {
            if (lazy.IsValueCreated)
            {
                foreach (var logger in Loggers)
                {
                    logger.Log(Level.Warning, message, caller, file, line);
                }
            }
        }
        #endregion
    }
}
