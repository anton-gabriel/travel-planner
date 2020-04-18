using System;
using TravelPlannerServer.Utils;

namespace TravelPlannerServer
{
    internal sealed class Program
    {
        static void Main()
        {
            using Server server = new Server(Configuration.Instance.Settings.ServerData)
            {
                CloseServerAction = () => Console.ReadKey()
            };
            server.Start();
            Console.WriteLine("Press any key to exit...");
        }
    }
}
