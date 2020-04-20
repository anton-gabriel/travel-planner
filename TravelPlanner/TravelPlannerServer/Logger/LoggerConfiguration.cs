namespace TravelPlannerServer.Logger
{
    internal static class LoggerConfiguration
    {
        public static ILoggerFacade GetLogger()
        {
            TravelPlannerLogger logger = TravelPlannerLogger.Instance;
            logger.AddLogger(new ConsoleLogger());
            logger.AddLogger(new FileLogger());
            return logger;
        }
    }
}
