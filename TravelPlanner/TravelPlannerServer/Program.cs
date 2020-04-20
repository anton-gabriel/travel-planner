using System;
using TravelPlannerServer.Logger;
using TravelPlannerServer.Utils;

namespace TravelPlannerServer
{
    internal sealed class Program
    {
        static void Main()
        {
            var logger = LoggerConfiguration.GetLogger();
            logger.Info("Application started.");

            using Server server = new Server(Configuration.Instance.Settings.ServerData)
            {
                CloseServerAction = () => Console.ReadKey()
            };
            server.Start();
            Console.WriteLine("Press any key to exit...");
        }
    }
}
