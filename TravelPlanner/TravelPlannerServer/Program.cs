using System;
using TravelPlannerServer.Logger;
using TravelPlannerServer.Model.DataAccess;
using TravelPlannerServer.Model.Entity;
using TravelPlannerServer.Utils;
using TravelPlannerServer.Utils.Enums;

namespace TravelPlannerServer
{
    internal sealed class Program
    {
        static void Main()
        {
            var logger = LoggerConfiguration.GetLogger();
            using Server server = new Server(Configuration.Instance.Settings.ServerData)
            {
                CloseServerAction = () => Console.ReadKey()
            };
            server.Start();
        }
    }
}
