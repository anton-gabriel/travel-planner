using System;
using TravelPlannerServer.Utils;

namespace TravelPlannerServer
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
            using Server server = new Server(Configuration.Instance.Settings.ServerData)
            {
                CloseServerAction = () => Console.ReadKey()
            };
            server.Start();
        }
    }
}
